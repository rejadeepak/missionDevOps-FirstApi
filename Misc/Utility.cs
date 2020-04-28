using System;
using System.Text;
namespace VSCodeEventBus.Controllers.Misc
{
    public static class Utility
    {
        public static string FileContent()
        {
            var builder = new StringBuilder();

            builder.Append("Id,Name")
            .AppendLine("1,Deepak Reja")
            .AppendLine("2,Kavya Reja");

            return builder.ToString();
        }
    }
}