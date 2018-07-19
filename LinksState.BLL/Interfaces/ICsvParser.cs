using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinksState.BLL.Interfaces
{
    public interface ICsvParser
    {
        IEnumerable<IEnumerable<string>> GetContent(byte[] csv);
    }
}
