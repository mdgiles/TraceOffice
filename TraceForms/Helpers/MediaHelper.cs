using FlexInterfaces.Core;
using FlexModel;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms.Helpers
{
    internal static class MediaHelper
    {
        internal static void FindOrAddDetail(FlextourEntities context, Guid? supplierGuid, string table, string linkValue, string productType,
            string recType, string language, string code, string data)
        {
            //language and productType should be null if not required, never string.Empty
            var detail = context.DETAIL.FirstOrDefault(d => d.LINK_TABLE == table && d.LINK_VALUE == linkValue && d.Language_Code == language
                && d.RECTYPE == recType && d.ProductType == productType && d.CODE == code && d.Supplier_GUID == supplierGuid);
            if (detail == null) {
                detail = new DETAIL() {
                    LINK_TABLE = table,
                    LINK_VALUE = linkValue,
                    ProductType = productType,
                    RECTYPE = recType,
                    Language_Code = language,
                    CODE = code,
                    Supplier_GUID = supplierGuid
                };
                context.DETAIL.AddObject(detail);
            }
            detail.NOTE = data;
        }

        internal static MEDIARPT CheckAndCreateNewMediaRpt(FlextourEntities context, string rptType, string type, string code, string language,
            DateTime? resDate)
        {
            MEDIARPT rpt = null;
            rpt = context.MEDIARPT.FirstOrDefault(m => m.RPT_TYPE == rptType && m.TYPE == type && m.CODE == code && m.LANG == language
                && m.RESDATE_START == resDate);
            if (rpt == null) {
                rpt = new MEDIARPT();
                rpt.CODE = code;
                rpt.TYPE = type;
                rpt.RPT_TYPE = rptType;
                rpt.LANG = language;
                rpt.AGENCY = string.Empty;
                rpt.CAT = string.Empty;
                rpt.DESC = string.Empty;
                rpt.RPT_FILE = string.Empty;
                rpt.Inactive = false;       //no need for this to be inactive because all the infos in it will be inactive
                rpt.ChgDate = DateTime.Now;
                rpt.RESDATE_START = resDate;
                rpt.Inhouse = false;
            }
            return rpt;
        }

        internal static MEDIAINFO CheckAndCreateNewMediaInfo(FlextourEntities context, string section, string title, string type, string code, string cat,
            string language, bool? inHouse, DateTime? resDate)
        {
            return CheckAndCreateNewMediaInfo(context, section, title, type, code, cat, language, inHouse, resDate, null, null, null, false);
        }

        internal static MEDIAINFO CheckAndCreateNewMediaInfo(FlextourEntities context, string section, string title, string type, string code, string cat,
            string language, bool? inHouse, DateTime? resDate, DateTime? svcStart, DateTime? svcEnd, string room, bool inactive)
        {
            MEDIAINFO info = null;
            //Check and update in case this is run multiple times on the same day
            info = context.MEDIAINFO.FirstOrDefault(m => m.SECTION == section && m.TYPE == type && m.CODE == code && m.CAT == cat
                && m.ResDate_Start == resDate && m.SvcDate_Start == svcStart && m.SvcDate_End == svcEnd && m.ResDate_End == null
                && m.ROOM == room && m.LANG == language && string.IsNullOrEmpty(m.Agency) && (inHouse ?? m.Inhouse) == m.Inhouse);
            if (info == null) {
                info = new MEDIAINFO {
                    ResDate_Start = resDate,
                    CODE = code,
                    TYPE = type,
                    SECTION = section,
                    //info.ResDate_Start = resDate;
                    LANG = language,
                    Inactive = inactive,
                    Agency = string.Empty,
                    Inhouse = inHouse ?? false,
                    CAT = cat,
                    ROOM = room,
                    SvcDate_Start = svcStart,
                    SvcDate_End = svcEnd,
                    ChgDate = DateTime.Now
                };
            }
            if (title.Length > 100) {
                info.TITLE = title.Substring(0, 100);
            }
            else {
                info.TITLE = title;
            }
            return info;
        }

        internal static MEDIAINFO DeactivateMediaInfo(FlextourEntities context, string section, string type, string code, string cat,
            string language)
        {
            MEDIAINFO info = null;
            info = context.MEDIAINFO.FirstOrDefault(m => m.SECTION == section && m.TYPE == type && m.CODE == code && m.CAT == cat
                  && m.LANG == language && string.IsNullOrEmpty(m.Agency));
            if (info != null) {
                info.Inactive = true;
                return info;
            }
            else {
                return new MEDIAINFO();
            }
        }

        internal static void CheckAndAddInfoToReports(FlextourEntities context, MEDIARPT[] addToReports, MEDIAINFO info, short? position)
        {
            foreach (var rpt in addToReports) {
                MediaRptItem rptItem = null;
                if (rpt.ID > 0 && info.ID > 0) {
                    continue;
                    //Checking each existing report and section to see if they are linked is too slow...

                    //If the report and media info section were previously saved, check if they were also linked
                    //together by MediaRptItem
                    //rptItem = context.MediaRptItem.FirstOrDefault(mri => mri.REPORT_ID == rpt.ID && mri.SECTION_ID == info.ID);
                }
                if (rptItem == null) {
                    rptItem = new MediaRptItem();
                    rptItem.MEDIARPT = rpt;
                    rptItem.MEDIARPT.ChgDate = DateTime.Now;
                    rptItem.MEDIAINFO = info;
                    rptItem.POSITION = position;
                    rpt.MediaRptItem.Add(rptItem);
                }
            }
        }

        internal static string GetOrPutImage(ICoreSys sys, string type, string code, string supplier, string masterCity, string image, string tag,
            bool createThumbnail)
        {
            if (string.IsNullOrEmpty(Configurator.AzureStorageConnectionString)) {
                return GetImage(sys, type, code, supplier, masterCity, image, tag, createThumbnail);
            }
            else {
                return PutImageToBlob(sys, type, code, supplier, masterCity, image, tag, createThumbnail);
            }
        }

        internal static string PutImageToBlob(ICoreSys sys, string type, string code, string supplier, string masterCity, string image, string tag,
            bool createThumbnail)
        {
            if (!string.IsNullOrEmpty(image) && Configurator.DownloadImages) {
                try {
                    string relativePath = $@"{Configurator.PhotosPath}{type}\{masterCity}\{code}\";
                    Uri uri = new Uri(image);
                    string filename = $"{code}_{supplier}_{tag}{Path.GetFileName(uri.AbsolutePath)}";
                    //TODO: this works for some CDNs which provide image paths with no extensions, eg https://cdn.filestackcontent.com/jqj2VclEQ3KB1oXqOJk0
                    //That assumes that the file is a jpeg, which it is for FareHabor, but might not always be so
                    FileInfo file = new FileInfo(filename);
                    if (string.IsNullOrEmpty(file.Extension)) {
                        filename += ".jpg";
                    }
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Configurator.AzureStorageConnectionString);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference("images");
                    //CloudBlobContainer container = blobClient.GetContainerReference(sys.Settings.ImagesContainer);
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(relativePath + filename);
                    //Don't download or upload the images if they already exist
                    if (Configurator.OverwriteImages || !blockBlob.Exists()) {
                        Console.WriteLine($"   Downloading image {filename}");
                        using (WebClient webClient = new WebClient()) {
                            byte[] data = webClient.DownloadData(uri);
                            if (createThumbnail) {
                                Console.WriteLine($"   Creating thumbnail");
                                ImageConverter converter = new ImageConverter();
                                Image fullSize = (Bitmap)converter.ConvertFrom(data);
                                Image thumb = CreateThumbnail(fullSize);
                                data = (byte[])converter.ConvertTo(thumb, typeof(byte[]));
                            }
                            //Use MemoryStream because it abstracts the process of having to loop through buffers of byte data
                            using (MemoryStream memoryStream = new MemoryStream(data)) {
                                blockBlob.UploadFromStream(memoryStream);
                            }
                        }
                    }
                    return relativePath + filename;
                }
                catch (Exception ex) {
                    NLog.LogManager.GetCurrentClassLogger().Error(ex, image);
                    return null;
                }
            }
            else {
                return null;
            }
        }

        internal static string GetImage(ICoreSys sys, string type, string code, string supplier, string masterCity, string image, string tag,
            bool createThumbnail)
        {
            if (!string.IsNullOrEmpty(image) && Configurator.DownloadImages) {
                try {
                    string relativePath = $@"{Configurator.PhotosPath}{type}\{masterCity}\{code}\";
                    string fullPath = sys.Settings.ImagesRoot + relativePath;
                    Directory.CreateDirectory(fullPath);
                    Uri uri = new Uri(image);
                    string filename = $"{code}_{supplier}_{tag}{Path.GetFileName(uri.AbsolutePath)}";
                    //TODO: this works for some CDNs which provide image paths with no extensions, eg https://cdn.filestackcontent.com/jqj2VclEQ3KB1oXqOJk0
                    //That assumes that the file is a jpeg, which it is for FareHabor, but might not always be so
                    FileInfo file = new FileInfo(filename);
                    if (string.IsNullOrEmpty(file.Extension)) {
                        filename += ".jpg";
                    }
                    //Don't download the images if they already exist
                    if (Configurator.OverwriteImages || !File.Exists(fullPath + filename)) {
                        Console.WriteLine($"   Downloading image {filename}");
                        using (WebClient webClient = new WebClient()) {
                            if (createThumbnail) {
                                byte[] data = webClient.DownloadData(uri);
                                Console.WriteLine($"   Creating thumbnail");
                                ImageConverter converter = new ImageConverter();
                                Image fullSize = (Bitmap)converter.ConvertFrom(data);
                                Image thumb = CreateThumbnail(fullSize);
                                thumb.Save(fullPath + filename);
                            }
                            else {
                                webClient.DownloadFile(uri, fullPath + filename);
                            }
                        }
                    }
                    return relativePath + filename;
                }
                catch (Exception ex) {
                    NLog.LogManager.GetCurrentClassLogger().Error(ex, image);
                    return null;
                }
            }
            else {
                return null;
            }
        }

        internal static bool CreateThumbnailAbort()
        {
            return false;
        }

        internal static Image CreateThumbnail(Image fullSizeImg, int width = 128, int height = 128)
        {
            Image.GetThumbnailImageAbort callBack = new Image.GetThumbnailImageAbort(CreateThumbnailAbort);
            return fullSizeImg.GetThumbnailImage(width, height, callBack, IntPtr.Zero);
        }

        internal static void CheckAndAddResource(FlextourEntities context, List<RESOURCE> resources, MEDIAINFO section, string imagePath,
            string description, string resolution)
        {
            if (!string.IsNullOrEmpty(imagePath)) {
                bool resourceExists = false;
                if (section.ID != 0) {
                    string id = section.ID.ToString();
                    resourceExists = context.RESOURCE.Any(r => r.LINK_TABLE == "MEDIAITEM" && r.RECTYPE == "IMAGE"
                    && r.ITEM == imagePath && r.LINK_VALUE == id);
                }
                if (!resourceExists) {
                    RESOURCE resource = new RESOURCE();
                    resource.LINK_TABLE = "MEDIAITEM";
                    resource.RECTYPE = "IMAGE";
                    resource.TAG = resolution;       //resolution
                    resource.ITEM = imagePath;
                    if (description.Length <= 50) {
                        resource.DESCRIPTION = description;
                    }
                    else {
                        resource.DESCRIPTION = description.Substring(0, 50);
                    }
                    resources.Add(resource);
                }
            }
        }

        /// <summary>
        /// Check whether any property in a COMP object has changed, and if so, set the ChgDate
        /// </summary>
        /// <remarks>
        /// The object must be attached to the context for this to work, otherwise an exception will be thrown
        /// </remarks>
        internal static void SetServiceChgDate(FlextourEntities context, COMP comp, DateTime updated, string user)
        {
            if (comp.IsModified(context)) {
                comp.LAST_UPD = updated;
                comp.UPD_INIT = user;
            }
        }

        internal static void SetCxlfeeChgDate(FlextourEntities context, CXLFEE cxlFee, DateTime updated, string user)
        {
            if (cxlFee.IsModified(context)) {
                cxlFee.LAST_UPD = updated;
                cxlFee.UPD_INIT = user;
            }
        }

        /// <summary>
        /// Check whether any property in a MEDIAINFO section has changed, and if so, set the ChgDate
        /// </summary>
        /// <remarks>
        /// The object must be attached to the context for this to work, otherwise an exception will be thrown
        /// </remarks>
        internal static void SetMediaInfosChgDate(FlextourEntities context, List<MEDIAINFO> infos, DateTime updated)
        {
            //http://stackoverflow.com/a/7115649
            foreach (var info in infos) {
                if (info.IsModified(context)) {
                    info.ChgDate = updated;
                }
            }
        }

        internal async static Task RemoveFromSearchAPIs(string type, string code)
        {
            Dictionary<string, string> headers = new Dictionary<string, string> {
                { "api-key", "71919D0B071DE1D8378F9F89F559FEFB" },
            };


            JObject content = new JObject(
                new JProperty("value",
                    new JArray(
                        new JObject(
                            new JProperty("@search.action", "delete"),
                            new JProperty("Id", $"service-{code}")
                        )
                    )
                )
            );

            await ApiInvoker.SendRequestPost($"https://tourschain.search.windows.net/indexes/product-search-index-zh/docs/index?api-version=2017-11-11",
                content.ToString(), headers);

            string result = await ApiInvoker.SendRequestGet(
                $"https://tourschain.search.windows.net/indexes/service-info-index/docs?api-version=2017-11-11&$filter=Product_Code eq '{code}' and Product_Type eq '{type}'",
                null, headers);
            dynamic obj = JsonConvert.DeserializeObject(result);
            foreach (dynamic foo in obj.value) {
                string id = foo.Id;
                content = new JObject(
                    new JProperty("value",
                        new JArray(
                            new JObject(
                                new JProperty("@search.action", "delete"),
                                new JProperty("Id", $"{id}")
                            )
                        )
                    )
                );
                result = await ApiInvoker.SendRequestPost($"https://tourschain.search.windows.net/indexes/service-info-index/docs/index?api-version=2017-11-11",
                    content.ToString(), headers);
            }
        }


    }
}
