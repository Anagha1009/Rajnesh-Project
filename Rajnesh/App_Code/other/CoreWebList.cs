using System;
using System.Collections.Generic;
using System.Data;

namespace yo_lib
{
   public class CoreWebList<T> : List<T>
   {
      private static bool m_enforceKeysInDataTableConversion;

      public CoreWebList()
      {
         m_enforceKeysInDataTableConversion = false;
      }

      public bool EnforceKeysInDataTableConversion
      {
         get { return m_enforceKeysInDataTableConversion; }
         set { m_enforceKeysInDataTableConversion = value; }
      }

      public static explicit operator DataTable(CoreWebList<T> list)
      {
         IDataTableConverter<T> converter = new DataTableConverter<T>(m_enforceKeysInDataTableConversion);
         return converter.GetDataTable(list);
      }
   }
}
