using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jayrideexam.Models
{
    public class TaskTwoRequest
    {
        public string ipAddress { get; set; }
    }

    public class TaskTwoResponse
    {
        public City city { get; set; }
        public Continent continent { get; set; }
        public Country country { get; set; }
        public Location location { get; set; }

        public State state { get; set; }
        public List<Datasource> datasource { get; set; }
        public string ip { get; set; }
    }


    public class City
    {
        public string name { get; set; }
    }

    public class Continent
    {
        public string code { get; set; }
        public int geoname_id { get; set; }

        public string name { get; set; }
    }

    public class Country
    {
        public int geoname_id { get; set; }
        public string iso_code { get; set; }
        public string name { get; set; }
        public string name_native { get; set; }
        public string phone_code { get; set; }
        public string capital { get; set; }
        public string currency { get; set; }
        public string flag { get; set; }
        public List<Language> languages { get; set; }
    }

    public class Datasource
    {
        public string name { get; set; }
        public string attribution { get; set; }
        public string license { get; set; }
    }

    public class Language
    {
        public string iso_code { get; set; }
        public string name { get; set; }
        public string name_native { get; set; }
    }

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class State
    {
        public string name { get; set; }
    }
}
