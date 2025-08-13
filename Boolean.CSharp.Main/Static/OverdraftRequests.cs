using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Static
{
    public static class OverdraftRequests
    {
        public static List<OverdraftRequest> Requests { get; } = new();

        public static OverdraftRequest GetRequest(Guid id)
        {
            var request = Requests.Where(r => r.Account == id).FirstOrDefault();

            if (request == null)
                return null;

            Requests.Remove(request);
            return request;
        }
    }
}
