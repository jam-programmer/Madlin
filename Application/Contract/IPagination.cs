using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract;

public interface IPagination
{
    public int curentPage { set; get; }
    public int pageSize { set; get; }
    public string keyword { set; get; }
}