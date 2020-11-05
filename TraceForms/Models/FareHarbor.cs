using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms.Models.FareHarbor
{
    public class Company
    {
        public string Currency { get; set; }

        public string Shortname { get; set; }

        public string Name { get; set; }
    }

    public class CompaniesRS : CommonRS
    {
        public override List<T> GetData<T>()
        {
            if (Companies == null) {
                return new List<T>();
            }

            return Companies.OfType<T>().ToList();
        }

        public List<Company> Companies { get; set; }
    }


    public class EffectiveCancellationPolicy
    {
        public double Cutoff_hours_before { get; set; }
        public string Type { get; set; }
    }

    public class Address
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Postal_code { get; set; }
        public string Country { get; set; }
    }

    public class Location
    {
        public string Google_place_id { get; set; }
        public string Note_safe_html { get; set; }
        public double? Longitude { get; set; }
        public string Note { get; set; }
        public string Tripadvisor_url { get; set; }
        public Address Address { get; set; }
        public double? Latitude { get; set; }
        public int Pk { get; set; }
        public string Type { get; set; }
    }

    public class CustomerPrototype
    {
        public string Note { get; set; }
        public int Pk { get; set; }
        public int Total { get; set; }
        public string Display_name { get; set; }
        public int Total_including_tax { get; set; }
        public bool Selected { get; set; }
        public short? FromAge { get; set; }
        public short? ToAge { get; set; }
        public int? InternalId { get; set; }
        public string PaxType { get; set; }
    }

    public class Item
    {
        public bool Selected { get; set; }
        public string InternalCode { get; set; }
        public string Image_cdn_url { get; set; }
        public string Description_text { get; set; }
        public EffectiveCancellationPolicy Effective_cancellation_policy { get; set; }
        public string Description { get; set; }
        public List<string> Description_bullets { get; set; }
        public string Booking_notes_safe_html { get; set; }
        public string Cancellation_policy { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Location> Locations { get; set; }
        public bool Is_pickup_ever_available { get; set; }
        public string Headline { get; set; }
        public string Description_safe_html { get; set; }
        public string Cancellation_policy_safe_html { get; set; }
        public string Location { get; set; }
        public string Booking_notes { get; set; }
        public int Pk { get; set; }
        public List<Image> Images { get; set; }
        public List<CustomerPrototype> Customer_prototypes { get; set; }
        public double Tax_percentage { get; set; }
        public string Name { get; set; }
        public decimal StartingPrice { get; set; }
        public bool AlreadyImported { get; set; }
    }

    public class Image
    {
        public string Image_cdn_url { get; set; }
        public int Pk { get; set; }
        public string Gallery { get; set; }
    }

    public class Tag
    {
        public string Name { get; set; }
    }

    public class ItemsRS : CommonRS
    {
        public override List<T> GetData<T>()
        {
            if (Items == null) {
                return new List<T>();
            }

            return Items.OfType<T>().ToList();
        }

        public List<Item> Items { get; set; }
    }

    public class ItemsRQ : CommonRQ
    {
        public string detailed { get; set; }
    }

    public class CommonRQ { }

    public abstract class CommonRS
    {
        /// <summary>
        /// The purpose of this method is to allow implementing classes to return their collections as generics using a common
        /// format, so that there doesn't have to be a method per type
        /// </summary>
        public abstract List<T> GetData<T>();
    }
}
