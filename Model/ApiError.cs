using System;

namespace VSCodeEventBus.Model
{
    public class ApiError{

        public string Source { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

    }
}