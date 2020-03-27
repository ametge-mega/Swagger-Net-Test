﻿using System;
using System.IO;
using System.Net.Http;
using System.Web.Http;
using WebApi.OutputCache.V2;

namespace Swagger_Test
{
    public class RandomController : ApiController
    {
        private static Random rnd = new Random();

        internal Color RandomColor
        {
            get
            {
                return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
        }

        [CacheOutput(ClientTimeSpan = 5, ServerTimeSpan = 5)]
        public Color GetRandomColor()
        {
            return RandomColor;
        }

        [CacheOutput(ClientTimeSpan = 10, ServerTimeSpan = 10)]
        public int GetRandomNumber(int max)
        {
            return rnd.Next(max);
        }
    }
}