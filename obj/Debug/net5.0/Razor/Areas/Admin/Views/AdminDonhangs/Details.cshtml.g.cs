#pragma checksum "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46f1401d8fe5d56e6bf68ab4d97069c0a54ebacf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminDonhangs_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminDonhangs/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46f1401d8fe5d56e6bf68ab4d97069c0a54ebacf", @"/Areas/Admin/Views/AdminDonhangs/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"031fc6503452a4d5746b848b41339db39b360ca1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminDonhangs_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LUANVANTOTNGHIEP_VODUCANKHANG.Models.Donhang>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("30"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("30"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";
    List<Chitietdonhang> chitietDonHang = ViewBag.ChiTietDH;


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"d-flex flex-column justify-content-center align-items-center\" id=\"order-heading\">\r\n    <div class=\"text-uppercase\">\r\n        <p>CHI TIẾT ĐƠN HÀNG</p>\r\n    </div>\r\n    <div class=\"h4\" style=\"color: #777\">");
#nullable restore
#line 13 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
                                   Write(Model.Ngaytaodon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n    <div class=\"pt-1\">\r\n        <p>Đơn Hàng ID #");
#nullable restore
#line 15 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
                   Write(Model.DonhangId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
    </div>
    <div class=""btn close text-white""> &times; </div>
</div>
<div class=""wrapper bg-white"">
    <div class=""table-responsive"">
        <table class=""table table-borderless"">
            <thead>
                <tr class=""text-uppercase text-muted"">
                    <th scope=""col"">Họ Và Tên</th>
                    <th scope=""col"" class=""text-right"">TỔNG TIỀN</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope=""row""> ");
#nullable restore
#line 30 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
                                Write(Model.Khachhang.Hovaten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <td class=\"text-right\"><b>");
#nullable restore
#line 31 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
                                         Write(Model.Tongtien.Value.ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VND</b></td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n");
#nullable restore
#line 36 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
     if (chitietDonHang != null && chitietDonHang.Count() > 0)
    {
        foreach (var item in chitietDonHang)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex justify-content-start align-items-center list py-1\">\r\n                <div><b>Qty: ");
#nullable restore
#line 41 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
                        Write(item.Soluong);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></div>\r\n                <div class=\"mx-3\"> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "46f1401d8fe5d56e6bf68ab4d97069c0a54ebacf7565", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1570, "~/images/HinhAnh/", 1570, 17, true);
#nullable restore
#line 42 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
AddHtmlAttributeValue("", 1587, item.Sanpham.Hinhanh, 1587, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 42 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
AddHtmlAttributeValue("", 1615, item.Sanpham.Hinhanh, 1615, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" </div>\r\n                <div class=\"order-item\">");
#nullable restore
#line 43 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
                                   Write(item.Sanpham.Tensanpham);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            </div>\r\n");
#nullable restore
#line 45 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""pt-2 border-bottom mb-3""></div>               
            <div class=""d-flex justify-content-start align-items-center pb-4 pl-3 border-bottom"">
                <div class=""text-muted""> <button class=""text-white btn"">Xác Nhận Đơn Hàng</button> </div>
               
            </div>
        
            <div class=""row border rounded p-1 my-3"">
                <div class=""col-md-6 py-3"">
                    <div class=""d-flex flex-column align-items start"">
                        <b>Địa Chỉ Giao Hàng</b>
                        <p class=""text-justify pt-2"">");
#nullable restore
#line 57 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\AdminDonhangs\Details.cshtml"
                                                Write(Model.Diachigiaohang);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                    </div>
                </div>
                <div class=""col-md-6 py-3"">
                    <div class=""d-flex flex-column align-items start"">
                        <b>Lưu Ý</b>
                        <p class=""text-justify pt-2"">James Thompson, 356 Jonathon Apt.220,</p>
                    </div>
                </div>
            </div>
        </div>



");
            WriteLiteral(@"
<style>
* {
    padding: 0;
    margin: 0;
    box-sizing: border-box;
    font-family: 'Roboto', sans-serif
}

body {
    background-color: #7C4135
}

#order-heading {
    background-color: #edf4f7;
    position: relative;
    border-top-left-radius: 25px;
    max-width: 800px;
    padding-top: 20px;
    margin: 30px auto 0px
}

#order-heading .text-uppercase {
    font-size: 0.9rem;
    color: #777;
    font-weight: 600
}

#order-heading .h4 {
    font-weight: 600
}

#order-heading .h4+div p {
    font-size: 0.8rem;
    color: #777
}

.close {
    padding: 10px 15px;
    background-color: #777;
    border-radius: 50%;
    position: absolute;
    right: -15px;
    top: -20px
}

.wrapper {
    padding: 0px 50px 50px;
    max-width: 800px;
    margin: 0px auto 40px;
    border-bottom-left-radius: 25px;
    border-bottom-right-radius: 25px
}

.table th {
    border-top: none
}

.table thead tr.text-uppercase th {
    font-size: 0.8rem;
    padding-lef");
            WriteLiteral(@"t: 0px;
    padding-right: 0px
}

.table tbody tr th,
.table tbody tr td {
    font-size: 0.9rem;
    padding-left: 0px;
    padding-right: 0px;
    padding-bottom: 5px
}

.table-responsive {
    height: 100px
}

.list div b {
    font-size: 0.8rem
}

.list .order-item {
    font-weight: 600;
    color: #6db3ec
}

.list:hover {
    background-color: #f4f4f4;
    cursor: pointer;
    border-radius: 5px
}

label {
    margin-bottom: 0;
    padding: 0;
    font-weight: 900
}

button.btn {
    font-size: 0.9rem;
    background-color: #66cdaa
}

button.btn:hover {
    background-color: #5cb99a
}

.price {
    color: #5cb99a;
    font-weight: 700
}

p.text-justify {
    font-size: 0.9rem;
    margin: 0
}

.row {
    margin: 0px
}

.subscriptions {
    border: 1px solid #ddd;
    border-left: 5px solid #ffa500;
    padding: 10px
}

.subscriptions div {
    font-size: 0.9rem
}


    body {
        font-size: 0.85rem
    }

    .subscriptions d");
            WriteLiteral("iv {\r\n        padding-left: 5px\r\n    }\r\n\r\n    img+label {\r\n        font-size: 0.75rem\r\n    }\r\n}\r\n</style>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LUANVANTOTNGHIEP_VODUCANKHANG.Models.Donhang> Html { get; private set; }
    }
}
#pragma warning restore 1591