using System;

namespace  VSCodeEventBus.Infrastructure
{
    public class ApiError{

        public string Source { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

    }
}