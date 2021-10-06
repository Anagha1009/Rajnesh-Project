using System;
using System.Collections.Generic;
using System.Data;

namespace yo_lib
{
   public interface IDataTableConverter<T>
   {
      DataTable GetDataTable(List<T> items);
   }
}
