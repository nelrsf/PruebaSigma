using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaSigma.Models
{

    public class Country
    {
        public string name { get; set; }
        public Root cities { get; set; }
        public List<string> states { get; set; }
        public List<string> citiesByState { get; set; }

        public string currentState { get; set; }

        public Country(string name, Root cities, List<string> states)
        {
            this.name = name;
            this.cities = cities;
            this.states = states;
            this.getCitiesByState(states[0]);
        }

        public List<string> getCitiesByState(string state)
        {
            this.citiesByState = (List<string>)cities.GetType().GetProperty(state).GetValue(cities, null);
            this.currentState = state;
            return this.citiesByState;
        }

        public void setCurrentState(string state) 
        {
            this.currentState = state;
        }
    }
}