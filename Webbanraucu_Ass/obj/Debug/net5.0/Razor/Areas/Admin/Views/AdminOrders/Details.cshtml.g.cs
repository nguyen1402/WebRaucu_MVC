#pragma checksum "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61c3eef0c13bc8268275ac305ca7a82698b893db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminOrders_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminOrders/Details.cshtml")]
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
#line 1 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\_ViewImports.cshtml"
using Webbanraucu_Ass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\_ViewImports.cshtml"
using Webbanraucu_Ass.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
using Webbanraucu_Ass.Extention;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61c3eef0c13bc8268275ac305ca7a82698b893db", @"/Areas/Admin/Views/AdminOrders/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec26216399cc5a44e84cecd580905e50b6a7674b", @"/Areas/Admin/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminOrders_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Webbanraucu_Ass.Models.Orders>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminOrders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("breadcrumb-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
  
    ViewData["Title"] = "Th??ng tin ????n h??ng #" + Model.OrderID;
    Layout = "~/Areas/Admin/Shared/_AdminLayout.cshtml";
    List<OrderDetails> _lsDetailsList = ViewBag.ChiTiet;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Page Container START -->
<div class=""page-container"">


    <!-- Content Wrapper START -->
    <div class=""main-content"">
        <div class=""page-header"">
            <div class=""header-sub-title"">
                <nav class=""breadcrumb breadcrumb-dash"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61c3eef0c13bc8268275ac305ca7a82698b893db5350", async() => {
                WriteLiteral("<i class=\"anticon anticon-home m-r-5\"></i>Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        <span class=""breadcrumb-item active"">Chi Ti???t H??a ????n</span>
                </nav>
            </div>
        </div>
        <div class=""container"">
            <div class=""card"">
                <div class=""card-body"">
                    <div id=""invoice"" class=""p-h-30"">
                        <div class=""m-t-15 lh-2"">
                            <div class=""inline-block"">
                                <img class=""img-fluid"" src=""assets/images/logo/logo.png""");
            BeginWriteAttribute("alt", " alt=\"", 1200, "\"", 1206, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                <address class=""p-l-10"">
                                    <span class=""font-weight-semibold text-dark"">BTNShop, DC.</span><br>
                                    <span>L???c Nam -</span><br>
                                    <span>B???c Giang</span><br>
                                    <abbr class=""text-dark"" title=""Phone"">S??? ??i???n tho???i:</abbr>
                                    <span>(+84) 0845512xxx </span>
                                </address>
                            </div>
                            <div class=""float-right"">
                                <h2>H??A ????N</h2>
                            </div>
                        </div>
                        <div class=""row m-t-20 lh-2"">
                            <div class=""col-sm-9"">
                                <h3 class=""p-l-10 m-t-10"">Kh??ch H??ng:</h3>
                                <address class=""p-l-10 m-t-10"">
                                    <span class=""font-weight-se");
            WriteLiteral("mibold text-dark\">?????a Ch???.</span><br>\r\n                                    <span>");
#nullable restore
#line 48 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                     Write(Model.Customers.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span><br>\r\n                                    <span>");
#nullable restore
#line 49 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                     Write(Model.Customers.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                </address>
                            </div>
                            <div class=""col-sm-3"">
                                <div class=""m-t-80"">
                                    <div class=""text-dark text-uppercase d-inline-block"">
                                        <span class=""font-weight-semibold text-dark"">M?? H??a ????n :</span>
                                    </div>
                                    <div class=""float-right"">#");
#nullable restore
#line 57 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                                         Write(Model.OrderID);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                                </div>
                                <div class=""text-dark text-uppercase d-inline-block"">
                                    <span class=""font-weight-semibold text-dark"">Ng??y t???o : </span>
                                </div>
                                <div class=""float-right"">");
#nullable restore
#line 62 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                                    Write(Model.OrderDat);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                            </div>
                        </div>
                        <div class=""m-t-20"">
                            <div class=""table-responsive"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th>No.</th>
                                            <th>S???n ph???m</th>
                                            <th>S??? l?????ng</th>
                                            <th>????n Gi??</th>
                                            <th>Th??nh Ti???n</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 78 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                     if (_lsDetailsList != null)
                                    {
                                        int i = 1;
                                        foreach (var iteam in _lsDetailsList)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <th>");
#nullable restore
#line 84 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                <td><a>");
#nullable restore
#line 85 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                                  Write(iteam.Products.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                                                <td>");
#nullable restore
#line 86 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                               Write(iteam.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 87 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                               Write(iteam.Products.Price.ToVnd());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 88 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                               Write(iteam.TotalMoney.ToVnd());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 90 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                            i++;
                                        }
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                            <div class=""row m-t-30 lh-1-8"">
                                <div class=""col-sm-12"">
                                    <div class=""float-right text-right"">
                                        <p>Gi???m gi??  :  0?? </p>
                                        <hr>
                                        <h3><span class=""font-weight-semibold text-dark"">T???ng ti???n :</span> ");
#nullable restore
#line 101 "D:\C#4\CodeC4\Webbanraucu_Ass\Webbanraucu_Ass\Areas\Admin\Views\AdminOrders\Details.cshtml"
                                                                                                       Write(Model.TotoMoney.ToVnd());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                                    </div>
                                </div>
                            </div>
                            <div class=""row m-t-30 lh-2"">
                                <div class=""col-sm-12"">
                                    <div class=""border-bottom p-v-20"">
                                        <p class=""text-opacity"" style=""text-align: center""><small><b>Ch??c Qu?? Kh??ch M???t Ng??y T???t L??nh</b></small></p>
                                    </div>
                                </div>
                            </div>
                            <div class=""row m-v-20"">
                                <div class=""col-sm-6"">
                                    <img class=""img-fluid text-opacity m-t-5"" width=""100"" src=""assets/images/logo/logo.png""");
            BeginWriteAttribute("alt", " alt=\"", 6344, "\"", 6350, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                                </div>
                                <div class=""col-sm-6 text-right"">
                                    <small><span class=""font-weight-semibold text-dark"">S??? ??i???n tho???i h??? tr???:</span> 0865514xxx</small>
                                    <br>
                                    <small>btnshop@fpt.edu.vn</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Webbanraucu_Ass.Models.Orders> Html { get; private set; }
    }
}
#pragma warning restore 1591
