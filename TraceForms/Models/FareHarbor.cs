using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraceForms.Models
{
    public class Company
    {
        public string Currency { get; set; }

        public string Shortname { get; set; }

        public string Name { get; set; }
    }

    class FareHarbor
    {
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
        public double Longitude { get; set; }
        public string Note { get; set; }
        public string Tripadvisor_url { get; set; }
        public Address Address { get; set; }
        public double Latitude { get; set; }
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
    }

    public class Item
    {
        public string Image_cdn_url { get; set; }
        public string Description_text { get; set; }
        public EffectiveCancellationPolicy Effective_cancellation_policy { get; set; }
        public string Description { get; set; }
        public List<object> Description_bullets { get; set; }
        public string Booking_notes_safe_html { get; set; }
        public string Cancellation_policy { get; set; }
        public List<object> Tags { get; set; }
        public List<Location> Locations { get; set; }
        public bool Is_pickup_ever_available { get; set; }
        public string Headline { get; set; }
        public string Description_safe_html { get; set; }
        public string Cancellation_policy_safe_html { get; set; }
        public string Location { get; set; }
        public string Booking_notes { get; set; }
        public int Pk { get; set; }
        public List<object> Images { get; set; }
        public List<CustomerPrototype> Customer_prototypes { get; set; }
        public double Tax_percentage { get; set; }
        public string Name { get; set; }
    }

    public class RootObject
    {
        public List<Item> Items { get; set; }
    }

    class CommonRQ
    {
    }

    class CommonRS
    {
    }
}
