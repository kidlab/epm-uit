using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EPM.Helpers
{
    public class WebUIHelper
    {
        // Slution from: http://stackoverflow.com/questions/964724/issue-with-aspcontentplaceholder-and-code-blocks
        public static bool ContainsControlsOrCodeBlock(ContentPlaceHolder placeHolder)
        {
            if (placeHolder.Controls.Count > 0)
                return true;

            return placeHolder.Controls.IsReadOnly;
        }

    }
}
