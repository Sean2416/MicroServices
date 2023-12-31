﻿namespace Mongo.Web.Models
{
    public class ResponseDto
    {
        public object? Data { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string ErrMsg { get; set; } = "";
    }
}
