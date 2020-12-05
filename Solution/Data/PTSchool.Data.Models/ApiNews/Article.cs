﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PTSchool.Data.Models.ApiNews
{
    public class Article
    {        
        public Guid Id { get; set; }

        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Content { get; set; }

        public string SourceId { get; set; }
        public Source Source { get; set; }
    }
}
