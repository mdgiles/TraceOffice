using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace TraceForms
{

    [ClassInterface(ClassInterfaceType.None)]
    public class MediaInfoWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            mediaInfoMaint xform1 = new mediaInfoMaint(sys) ;
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class MediaRptWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            MediaRptForm xform1 = new MediaRptForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class PackWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            packForm xform1 = new packForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class Comprod2Wrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            CommissionsForm xform1 = new CommissionsForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class CompWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            CompForm xform1 = new CompForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class CommLevelWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            CommLevelForm xform1 = new CommLevelForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class HratesWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            HRatesForm xform1 = new HRatesForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class HotelWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            HotelGenInfo xform1 = new HotelGenInfo(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class AgyWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            AgencyForm xform1 = new AgencyForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class SysfileWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            SysfileForm xform1 = new SysfileForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class ExtranetSecurityWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            ExtranetSecurityForm xform1 = new ExtranetSecurityForm(sys);
            xform1.ShowDialog();
        }
    }

	[ClassInterface(ClassInterfaceType.None)]
	public class RoutesWrapper : FlexInterfaces.Office.IFlexForm
	{
		public void Show(FlexInterfaces.Core.ICoreSys sys)
		{
			RouteForm xform1 = new RouteForm(sys);
			xform1.ShowDialog();
		}
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class RelatedProductsWrapper : FlexInterfaces.Office.IFlexForm
	{
		public void Show(FlexInterfaces.Core.ICoreSys sys)
		{
			RelatedProductsForm xform1 = new RelatedProductsForm(sys);
			xform1.ShowDialog();
		}
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class WaypointWrapper : FlexInterfaces.Office.IFlexForm
	{
		public void Show(FlexInterfaces.Core.ICoreSys sys)
		{
			WaypointForm xform1 = new WaypointForm(sys);
			xform1.ShowDialog();
		}
	}

	[ClassInterface(ClassInterfaceType.None)]
	public class CPRatesWrapper : FlexInterfaces.Office.IFlexForm
	{
		public void Show(FlexInterfaces.Core.ICoreSys sys)
		{
			CpRatesForm xform1 = new CpRatesForm(sys);
			xform1.ShowDialog();
		}
	}

    [ClassInterface(ClassInterfaceType.None)]
    public class BusWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            BusForm xform1 = new BusForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class BusAssignmentWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            BusAssignmentForm xform1 = new BusAssignmentForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class MGMRatesImportWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            MGMRatesImportForm xform1 = new MGMRatesImportForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class OperationsServiceListWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            OperationsServiceListForm xform1 = new OperationsServiceListForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class HotelProductionReportWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            HotelProductionReportForm xform1 = new HotelProductionReportForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class OperatorWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            OperatorForm xform1 = new OperatorForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class CountryWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            CountryForm xform1 = new CountryForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class CityWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            CityCodeForm xform1 = new CityCodeForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class PratesWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            PRatesForm xform1 = new PRatesForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class CurrencyWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            CurrencyForm xform1 = new CurrencyForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class ProductListWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            ProductListForm xform1 = new ProductListForm(sys);
            xform1.ShowDialog();
        }
    }

    [ClassInterface(ClassInterfaceType.None)]
    public class PCompWrapper : FlexInterfaces.Office.IFlexForm
    {
        public void Show(FlexInterfaces.Core.ICoreSys sys)
        {
            PCompForm xform1 = new PCompForm(sys);
            xform1.ShowDialog();
        }
    }
}

