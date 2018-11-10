using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace BeadCSharpMobileApp.iOS{

    public class Application {
        // This is the main entry point of the application.
        static void Main(string[] args){
            // to use a different Application Delegate class from "AppDelegate" specify here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
