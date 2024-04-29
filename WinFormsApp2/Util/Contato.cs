﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gweb.WhatsApp.Util
{
    public class Contato
    {
        public int id { get; set; }
        public string status { get; set; }
        public string value { get; set; }
        public Store store { get; set; }
        public Person person { get; set; }

        public override string ToString()
        {
            return $"ID: {id}, Status: {status}, Value: {value}, Store ID: {store?.id}, Days to Expire: {store?.daysToExpire}, Person ID: {person?.id}";
        }
    }

    public class Person
    {
        public int id { get; set; }

        public override string ToString()
        {
            return $"ID: {id}";
        }
    }

    public class Root
    {
        public int code { get; set; }
        public string status { get; set; }
        public List<Contato> data { get; set; }

        public override string ToString()
        {
            return $"Code: {code}, Status: {status}, Data Count: {data?.Count}";
        }
    }

    public class Store
    {
        public int id { get; set; }
        public int daysToExpire { get; set; }

        public override string ToString()
        {
            return $"ID: {id}, Days to Expire: {daysToExpire}";
        }
    }
}
