#pragma checksum "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efeb0282a44a056455e7c93bedb4c60344b06a0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TestThuocTinhNhanviens_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/TestThuocTinhNhanviens/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efeb0282a44a056455e7c93bedb4c60344b06a0d", @"/Areas/Admin/Views/TestThuocTinhNhanviens/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"031fc6503452a4d5746b848b41339db39b360ca1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_TestThuocTinhNhanviens_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LUANVANTOTNGHIEP_VODUCANKHANG.Models.Nhanvien>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Nhanvien</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Hovaten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Hovaten));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Matkhau));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Matkhau));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 33 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ngaytao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 36 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ngaytao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 39 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Cmnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 42 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Cmnd));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 45 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ngaysinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ngaysinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 51 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 54 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Diachi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 57 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Gioitinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 60 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Gioitinh));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 63 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Phanquyen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 66 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Phanquyen.PhanquyenId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 69 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Trangthai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 72 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
       Write(Html.DisplayFor(model => model.Trangthai.TrangthaiId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efeb0282a44a056455e7c93bedb4c60344b06a0d11339", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\HD3_VoDucAnKhang\LUANVANTOTNGHIEP_VODUCANKHANG\Areas\Admin\Views\TestThuocTinhNhanviens\Details.cshtml"
                           WriteLiteral(Model.TaikhoanId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efeb0282a44a056455e7c93bedb4c60344b06a0d13516", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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