using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModel
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Request_Token { get; set; }
    }
}
