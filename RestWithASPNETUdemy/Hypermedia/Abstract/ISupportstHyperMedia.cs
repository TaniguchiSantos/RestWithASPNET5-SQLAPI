using System.Collections.Generic;

namespace RestWithASPNETUdemy.Hypermedia.Abstract
{
    public interface ISupportstHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
