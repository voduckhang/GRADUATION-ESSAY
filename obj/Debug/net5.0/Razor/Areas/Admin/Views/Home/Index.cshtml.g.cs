#pragma checksum "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7f9a40423f8026712599b120ace3487d2d14ff0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\_ViewImports.cshtml"
using LUANVANTOTNGHIEP_VODUCANKHANG;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\_ViewImports.cshtml"
using LUANVANTOTNGHIEP_VODUCANKHANG.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7f9a40423f8026712599b120ace3487d2d14ff0", @"/Areas/Admin/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"031fc6503452a4d5746b848b41339db39b360ca1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LUANVANTOTNGHIEP_VODUCANKHANG.Models.Nhanvien>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "LoginAdmin";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

    LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews.LoginAdminViewModel loginAdminView = new LUANVANTOTNGHIEP_VODUCANKHANG.ModelViews.LoginAdminViewModel();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <style>
        .gradient-custom {
            /* fallback for old browsers */
            background: #6a11cb;
            /* Chrome 10-25, Safari 5.1-6 */
            background: -webkit-linear-gradient(to right, rgba(106, 17, 203, 1), rgba(37, 117, 252, 1));
            /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
            background: linear-gradient(to right, rgba(106, 17, 203, 1), rgba(37, 117, 252, 1))
        }
    </style>
");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 20 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\Home\Index.cshtml"
 if (User.Identity.IsAuthenticated == true)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"       <!-- Sale & Revenue Start -->
    <div class=""container-fluid pt-4 px-4"">
        <div class=""row g-4"">
            <div class=""col-sm-6 col-xl-3"">
                <div class=""bg-secondary rounded d-flex align-items-center justify-content-between p-4"">
                    <i class=""fa fa-chart-line fa-3x text-primary""></i>
                    <div class=""ms-3"">
                        <p class=""mb-2"">Today Sale</p>
                        <h6 class=""mb-0"">$1234</h6>
                    </div>
                </div>
            </div>
            <div class=""col-sm-6 col-xl-3"">
                <div class=""bg-secondary rounded d-flex align-items-center justify-content-between p-4"">
                    <i class=""fa fa-chart-bar fa-3x text-primary""></i>
                    <div class=""ms-3"">
                        <p class=""mb-2"">Total Sale</p>
                        <h6 class=""mb-0"">$1234</h6>
                    </div>
                </div>
            </div>
            <div clas");
            WriteLiteral(@"s=""col-sm-6 col-xl-3"">
                <div class=""bg-secondary rounded d-flex align-items-center justify-content-between p-4"">
                    <i class=""fa fa-chart-area fa-3x text-primary""></i>
                    <div class=""ms-3"">
                        <p class=""mb-2"">Today Revenue</p>
                        <h6 class=""mb-0"">$1234</h6>
                    </div>
                </div>
            </div>
            <div class=""col-sm-6 col-xl-3"">
                <div class=""bg-secondary rounded d-flex align-items-center justify-content-between p-4"">
                    <i class=""fa fa-chart-pie fa-3x text-primary""></i>
                    <div class=""ms-3"">
                        <p class=""mb-2"">Total Revenue</p>
                        <h6 class=""mb-0"">$1234</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Sale & Revenue End -->
    <!-- Sales Chart Start -->
    <div class=""container-fluid pt-4 px-4"">
        <div");
            WriteLiteral(@" class=""row g-4"">
            <div class=""col-sm-12 col-xl-6"">
                <div class=""bg-secondary text-center rounded p-4"">
                    <div class=""d-flex align-items-center justify-content-between mb-4"">
                        <h6 class=""mb-0"">Worldwide Sales</h6>
                        <a");
            BeginWriteAttribute("href", " href=\"", 3207, "\"", 3214, 0);
            EndWriteAttribute();
            WriteLiteral(@">Show All</a>
                    </div>
                    <canvas id=""worldwide-sales""></canvas>
                </div>
            </div>
            <div class=""col-sm-12 col-xl-6"">
                <div class=""bg-secondary text-center rounded p-4"">
                    <div class=""d-flex align-items-center justify-content-between mb-4"">
                        <h6 class=""mb-0"">Salse & Revenue</h6>
                        <a");
            BeginWriteAttribute("href", " href=\"", 3655, "\"", 3662, 0);
            EndWriteAttribute();
            WriteLiteral(@">Show All</a>
                    </div>
                    <canvas id=""salse-revenue""></canvas>
                </div>
            </div>
        </div>
    </div>
    <!-- Sales Chart End -->
    <!-- Recent Sales Start -->
    <div class=""container-fluid pt-4 px-4"">
        <div class=""bg-secondary text-center rounded p-4"">
            <div class=""d-flex align-items-center justify-content-between mb-4"">
                <h6 class=""mb-0"">Recent Salse</h6>
                <a");
            BeginWriteAttribute("href", " href=\"", 4156, "\"", 4163, 0);
            EndWriteAttribute();
            WriteLiteral(@">Show All</a>
            </div>
            <div class=""table-responsive"">
                <table class=""table text-start align-middle table-bordered table-hover mb-0"">
                    <thead>
                        <tr class=""text-white"">
                            <th scope=""col""><input class=""form-check-input"" type=""checkbox""></th>
                            <th scope=""col"">Date</th>
                            <th scope=""col"">Invoice</th>
                            <th scope=""col"">Customer</th>
                            <th scope=""col"">Amount</th>
                            <th scope=""col"">Status</th>
                            <th scope=""col"">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><input class=""form-check-input"" type=""checkbox""></td>
                            <td>01 Jan 2045</td>
                            <td>INV-0123</td>
                          ");
            WriteLiteral("  <td>Jhon Doe</td>\r\n                            <td>$123</td>\r\n                            <td>Paid</td>\r\n                            <td><a class=\"btn btn-sm btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 5360, "\"", 5367, 0);
            EndWriteAttribute();
            WriteLiteral(@">Detail</a></td>
                        </tr>
                        <tr>
                            <td><input class=""form-check-input"" type=""checkbox""></td>
                            <td>01 Jan 2045</td>
                            <td>INV-0123</td>
                            <td>Jhon Doe</td>
                            <td>$123</td>
                            <td>Paid</td>
                            <td><a class=""btn btn-sm btn-primary""");
            BeginWriteAttribute("href", " href=\"", 5829, "\"", 5836, 0);
            EndWriteAttribute();
            WriteLiteral(@">Detail</a></td>
                        </tr>
                        <tr>
                            <td><input class=""form-check-input"" type=""checkbox""></td>
                            <td>01 Jan 2045</td>
                            <td>INV-0123</td>
                            <td>Jhon Doe</td>
                            <td>$123</td>
                            <td>Paid</td>
                            <td><a class=""btn btn-sm btn-primary""");
            BeginWriteAttribute("href", " href=\"", 6298, "\"", 6305, 0);
            EndWriteAttribute();
            WriteLiteral(@">Detail</a></td>
                        </tr>
                        <tr>
                            <td><input class=""form-check-input"" type=""checkbox""></td>
                            <td>01 Jan 2045</td>
                            <td>INV-0123</td>
                            <td>Jhon Doe</td>
                            <td>$123</td>
                            <td>Paid</td>
                            <td><a class=""btn btn-sm btn-primary""");
            BeginWriteAttribute("href", " href=\"", 6767, "\"", 6774, 0);
            EndWriteAttribute();
            WriteLiteral(@">Detail</a></td>
                        </tr>
                        <tr>
                            <td><input class=""form-check-input"" type=""checkbox""></td>
                            <td>01 Jan 2045</td>
                            <td>INV-0123</td>
                            <td>Jhon Doe</td>
                            <td>$123</td>
                            <td>Paid</td>
                            <td><a class=""btn btn-sm btn-primary""");
            BeginWriteAttribute("href", " href=\"", 7236, "\"", 7243, 0);
            EndWriteAttribute();
            WriteLiteral(@">Detail</a></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <!-- Recent Sales End -->
    <!-- Widgets Start -->
    <div class=""container-fluid pt-4 px-4"">
        <div class=""row g-4"">
            <div class=""col-sm-12 col-md-6 col-xl-4"">
                <div class=""h-100 bg-secondary rounded p-4"">
                    <div class=""d-flex align-items-center justify-content-between mb-2"">
                        <h6 class=""mb-0"">Messages</h6>
                        <a");
            BeginWriteAttribute("href", " href=\"", 7821, "\"", 7828, 0);
            EndWriteAttribute();
            WriteLiteral(">Show All</a>\r\n                    </div>\r\n                    <div class=\"d-flex align-items-center border-bottom py-3\">\r\n                        <img class=\"rounded-circle flex-shrink-0\" src=\"#\"");
            BeginWriteAttribute("alt", " alt=\"", 8025, "\"", 8031, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 40px; height: 40px;"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 justify-content-between"">
                                <h6 class=""mb-0"">Jhon Doe</h6>
                                <small>15 minutes ago</small>
                            </div>
                            <span>Short message goes here...</span>
                        </div>
                    </div>
                    <div class=""d-flex align-items-center border-bottom py-3"">
                        <img class=""rounded-circle flex-shrink-0"" src=""#""");
            BeginWriteAttribute("alt", " alt=\"", 8645, "\"", 8651, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 40px; height: 40px;"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 justify-content-between"">
                                <h6 class=""mb-0"">Jhon Doe</h6>
                                <small>15 minutes ago</small>
                            </div>
                            <span>Short message goes here...</span>
                        </div>
                    </div>
                    <div class=""d-flex align-items-center border-bottom py-3"">
                        <img class=""rounded-circle flex-shrink-0"" src=""#""");
            BeginWriteAttribute("alt", " alt=\"", 9265, "\"", 9271, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 40px; height: 40px;"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 justify-content-between"">
                                <h6 class=""mb-0"">Jhon Doe</h6>
                                <small>15 minutes ago</small>
                            </div>
                            <span>Short message goes here...</span>
                        </div>
                    </div>
                    <div class=""d-flex align-items-center pt-3"">
                        <img class=""rounded-circle flex-shrink-0"" src=""#""");
            BeginWriteAttribute("alt", " alt=\"", 9871, "\"", 9877, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 40px; height: 40px;"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 justify-content-between"">
                                <h6 class=""mb-0"">Jhon Doe</h6>
                                <small>15 minutes ago</small>
                            </div>
                            <span>Short message goes here...</span> 
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-sm-12 col-md-6 col-xl-4"">
                <div class=""h-100 bg-secondary rounded p-4"">
                    <div class=""d-flex align-items-center justify-content-between mb-4"">
                        <h6 class=""mb-0"">Calender</h6>
                        <a");
            BeginWriteAttribute("href", " href=\"", 10672, "\"", 10679, 0);
            EndWriteAttribute();
            WriteLiteral(@">Show All</a>
                    </div>
                    <div id=""calender""></div>
                </div>
            </div>
            <div class=""col-sm-12 col-md-6 col-xl-4"">
                <div class=""h-100 bg-secondary rounded p-4"">
                    <div class=""d-flex align-items-center justify-content-between mb-4"">
                        <h6 class=""mb-0"">To Do List</h6>
                        <a");
            BeginWriteAttribute("href", " href=\"", 11105, "\"", 11112, 0);
            EndWriteAttribute();
            WriteLiteral(@">Show All</a>
                    </div>
                    <div class=""d-flex mb-2"">
                        <input class=""form-control bg-dark border-0"" type=""text"" placeholder=""Enter task"">
                        <button type=""button"" class=""btn btn-primary ms-2"">Add</button>
                    </div>
                    <div class=""d-flex align-items-center border-bottom py-2"">
                        <input class=""form-check-input m-0"" type=""checkbox"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 align-items-center justify-content-between"">
                                <span>Short task goes here...</span>
                                <button class=""btn btn-sm""><i class=""fa fa-times""></i></button>
                            </div>
                        </div>
                    </div>
                    <div class=""d-flex align-items-center border-bottom py-2"">
                        <input class=""form-check-input m-0""");
            WriteLiteral(@" type=""checkbox"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 align-items-center justify-content-between"">
                                <span>Short task goes here...</span>
                                <button class=""btn btn-sm""><i class=""fa fa-times""></i></button>
                            </div>
                        </div>
                    </div>
                    <div class=""d-flex align-items-center border-bottom py-2"">
                        <input class=""form-check-input m-0"" type=""checkbox"" checked>
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 align-items-center justify-content-between"">
                                <span><del>Short task goes here...</del></span>
                                <button class=""btn btn-sm text-primary""><i class=""fa fa-times""></i></button>
                            </div>
                        </div>
                   ");
            WriteLiteral(@" </div>
                    <div class=""d-flex align-items-center border-bottom py-2"">
                        <input class=""form-check-input m-0"" type=""checkbox"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 align-items-center justify-content-between"">
                                <span>Short task goes here...</span>
                                <button class=""btn btn-sm""><i class=""fa fa-times""></i></button>
                            </div>
                        </div>
                    </div>
                    <div class=""d-flex align-items-center pt-2"">
                        <input class=""form-check-input m-0"" type=""checkbox"">
                        <div class=""w-100 ms-3"">
                            <div class=""d-flex w-100 align-items-center justify-content-between"">
                                <span>Short task goes here...</span>
                                <button class=""btn btn-sm""><i class=""fa fa-times"">");
            WriteLiteral("</i></button>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- Widgets End -->\r\n");
#nullable restore
#line 280 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\Home\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section class=""vh-100 gradient-custom"">
        <div class=""container py-5 h-100"">
            <div class=""row d-flex justify-content-center align-items-center h-100"">
                <div class=""col-12 col-md-8 col-lg-6 col-xl-5"">
                    <div class=""card bg-dark text-white"" style=""border-radius: 1rem;"">
                        <div class=""card-body p-5 text-center"">

                            <div class=""mb-md-5 mt-md-4 pb-5"">

                                <a href=""/login-admin.html"" class=""btn btn-outline-light btn-lg px-5"">Login</a>



                            </div>

                            <p>Vui Lòng Đăng Nhập Để Sử Dụng Dịch Vụ</p>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
");
#nullable restore
#line 306 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LUANVANTOTNGHIEP_VODUCANKHANG.Models.Nhanvien> Html { get; private set; }
    }
}
#pragma warning restore 1591