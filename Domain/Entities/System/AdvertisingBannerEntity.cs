using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.System;

public class AdvertisingBannerEntity:BaseEntity
{
    public string? ImageOnePath {  get; set; }
    public string? ImageTwoPath {  get; set; }
    public string? ImageThreePath {  get; set; }
    public string? ImageFourPath {  get; set; }
    public string? ImageFivePath {  get; set; }
}
