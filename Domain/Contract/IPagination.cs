using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contract;

public interface IPagination
{
    public int currentPage { set; get; }
    public int pageSize { set; get; }
    public string keyword { set; get; }
}