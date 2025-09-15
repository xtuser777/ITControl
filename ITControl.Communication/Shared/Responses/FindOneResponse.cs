using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITControl.Communication.Shared.Responses;

public class FindOneResponse<T>
{
    public T? Data { get; init; }
}
