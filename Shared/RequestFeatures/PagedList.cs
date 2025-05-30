﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public MetaData MetaData { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new MetaData
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        } 

        public static PagedList<T> ToPagedList (IEnumerable<T> source, int pageNmber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNmber - 1) * pageSize)
                              .Take(pageSize)
                              .ToList();

            return new PagedList<T>(items, count, pageNmber, pageSize);
        }
    }
}
