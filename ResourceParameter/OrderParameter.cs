using System;
using System.ComponentModel.DataAnnotations;
namespace VSCodeEventBus.ResourceParameter
{
    public class OrderParameter
    {

        const int maxpageSize = 10;
        [Required]
        public int CustomerId { get; set; }
        public int PageNumber { get; set; }
        private int _pageSize = 10;
        public int PageSize
        {

            get => _pageSize;
            set => _pageSize = (value > maxpageSize) ? maxpageSize : value;

        }



    }
}