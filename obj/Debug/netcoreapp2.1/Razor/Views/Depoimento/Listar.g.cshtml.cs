#pragma checksum "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd18c876667920e8d742743a87cd1996bd3d1ed4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Depoimento_Listar), @"mvc.1.0.view", @"/Views/Depoimento/Listar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Depoimento/Listar.cshtml", typeof(AspNetCore.Views_Depoimento_Listar))]
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
#line 1 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
using Projeto_CarFel_CkeckPoint_Web.Models;

#line default
#line hidden
#line 2 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
using Projeto_CarFel_CheckPoint_Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd18c876667920e8d742743a87cd1996bd3d1ed4", @"/Views/Depoimento/Listar.cshtml")]
    public class Views_Depoimento_Listar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
     if (ViewBag.UserLog == 1)
    {
        ViewBag.Title = "Central de Depoimentos";
    }
    else
    {
        ViewBag.Title = "Depoimentos";
    }

#line default
#line hidden
#line 11 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
     
    Layout = "MasterPageDeslogado";

#line default
#line hidden
            BeginContext(297, 70, true);
            WriteLiteral("\r\n<div class=\"titulo flex-container\">\r\n    <div class=\"titulo-item\">\r\n");
            EndContext();
#line 17 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
         if (ViewBag.UserLog == 1)
        {

#line default
#line hidden
            BeginContext(414, 45, true);
            WriteLiteral("            <h2>Central de Depoimentos</h2>\r\n");
            EndContext();
#line 20 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(495, 34, true);
            WriteLiteral("            <h2>Depoimentos</h2>\r\n");
            EndContext();
#line 24 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
        }

#line default
#line hidden
            BeginContext(540, 40, true);
            WriteLiteral("        \r\n    </div>\r\n</div>\r\n\r\n<main>\r\n");
            EndContext();
#line 30 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
     if (ViewBag.UserLog == 1)
    { 

#line default
#line hidden
            BeginContext(620, 282, true);
            WriteLiteral(@"        <div class=""titulo"">
            <div class=""titulo-item"">
                <h2>Central de Depoimentos</h2>
            </div>
	    </div>
        <section class=""depoimentos depoimentos-pag"">
            <h2>Depoimentos</h2>

            <div class=""Usuarios-dep"">
");
            EndContext();
#line 41 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                 foreach (var dep in ViewData["Depoimentos"] as List<DepoimentoModel>)
                {
                    if (!dep.Aprovado)
                    {

#line default
#line hidden
            BeginContext(1072, 553, true);
            WriteLiteral(@"                        <div class=""user-dep"">
                            <div class=""flex-container"">
                                <div class=""dep-img"">
                                    <img src=""/imagem/user.png"" alt=""icone de usuario"">		
                                </div>
                                <div class=""dep-container"">          
                                    <div class=""dep-header flex-container"">
                                        <div class=""dh-text"">
                                            <p><b>");
            EndContext();
            BeginContext(1626, 16, false);
#line 53 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                                             Write(dep.Usuario.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1642, 57, true);
            WriteLiteral("</b></p>\r\n                                            <p>");
            EndContext();
            BeginContext(1700, 15, false);
#line 54 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                                          Write(dep.DataCriacao);

#line default
#line hidden
            EndContext();
            BeginContext(1715, 542, true);
            WriteLiteral(@"</p>
                                        </div>
                                        <!-- <div class=""dh-like flex-container"">
                                            <img src=""/imagem/like.png"" alt=""icone de like"" style=""width:2.5em; height: auto; margin-right: 0.5em;"">
                                            <p>100</p>
                                        </div> -->
                                    </div>
                                    <div class=""dep-main"">
                                        <p>");
            EndContext();
            BeginContext(2258, 9, false);
#line 62 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                                      Write(dep.Texto);

#line default
#line hidden
            EndContext();
            BeginContext(2267, 276, true);
            WriteLiteral(@"</p>
                                    </div>
                                    <div class=""dep-footer flex-container"">
                                        <div class=""df-aprovado"">
                                            <button style=""margin-right: 0.5em""><a");
            EndContext();
            BeginWriteAttribute("hreflang", " hreflang=\"", 2543, "\"", 2584, 2);
            WriteAttributeValue("", 2554, "/Depoimento/Aprovar?id=", 2554, 23, true);
#line 66 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
WriteAttributeValue("", 2577, dep.Id, 2577, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2585, 194, true);
            WriteLiteral(">Aprovado</a></button>\r\n                                        </div>\r\n                                        <div class=\"df-reprovado\">\r\n                                            <button><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2779, "\"", 2817, 2);
            WriteAttributeValue("", 2786, "/Depoimento/Reprovar?id=", 2786, 24, true);
#line 69 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
WriteAttributeValue("", 2810, dep.Id, 2810, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2818, 284, true);
            WriteLiteral(@">Reprovado</a></button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""dep-barra""></div>
                        </div>
");
            EndContext();
#line 76 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(3144, 183, true);
            WriteLiteral("            </div>\r\n\r\n            <div class=\"dep-buttons flex-container\">\r\n              <button><a href=\"/Pagina/Home\">Voltar</a></button>\r\n            </div>\t\r\n        </section>\r\n");
            EndContext();
#line 84 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
    }

    else
    {

#line default
#line hidden
            BeginContext(3353, 140, true);
            WriteLiteral("        <div class=\"titulo\">\r\n            <div class=\"titulo-item\">\r\n                <h2>Depoimentos</h2>\r\n            </div>\r\n\t    </div>\r\n");
            EndContext();
            BeginContext(3495, 615, true);
            WriteLiteral(@"        <section class=""depoimentos depoimentos-pag"">
            <h2>Depoimentos</h2>

            <div class=""user-dep-escrever"">
                <div class=""flex-container"">
                    <div class=""dep-img flex-container"" style=""justify-content: flex-end;"">
                        <img src=""/imagem/user.png"" alt=""icone de usuario"" style=""height: 3em;"">		
                    </div>
                    <div class=""dep-container-escrever"">
                        <div class=""dep-header flex-container"">
                            <div class=""dh-text"">
                                <p><b>");
            EndContext();
            BeginContext(4111, 19, false);
#line 105 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                                 Write(ViewBag.UsuarioLogN);

#line default
#line hidden
            EndContext();
            BeginContext(4130, 321, true);
            WriteLiteral(@"</b></p>
                            </div>
                        </div>
                        <textarea placeholder=""Deixe seu depoimento:"" class=""contato-item-form-input dep-textarea""></textarea>
                    </div>
                </div>	
            </div>

            <div class=""Usuarios-dep"">
");
            EndContext();
#line 114 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                 foreach (var dep in ViewData["Depoimentos"] as List<DepoimentoModel>)
                {
                    if (dep.Aprovado)
                    {

#line default
#line hidden
            BeginContext(4620, 553, true);
            WriteLiteral(@"                        <div class=""user-dep"">
                            <div class=""flex-container"">
                                <div class=""dep-img"">
                                    <img src=""/imagem/user.png"" alt=""icone de usuario"">		
                                </div>
                                <div class=""dep-container"">          
                                    <div class=""dep-header flex-container"">
                                        <div class=""dh-text"">
                                            <p><b>");
            EndContext();
            BeginContext(5174, 16, false);
#line 126 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                                             Write(dep.Usuario.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(5190, 57, true);
            WriteLiteral("</b></p>\r\n                                            <p>");
            EndContext();
            BeginContext(5248, 15, false);
#line 127 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                                          Write(dep.DataCriacao);

#line default
#line hidden
            EndContext();
            BeginContext(5263, 542, true);
            WriteLiteral(@"</p>
                                        </div>
                                        <!-- <div class=""dh-like flex-container"">
                                            <img src=""/imagem/like.png"" alt=""icone de like"" style=""width:2.5em; height: auto; margin-right: 0.5em;"">
                                            <p>100</p>
                                        </div> -->
                                    </div>
                                    <div class=""dep-main"">
                                        <p>");
            EndContext();
            BeginContext(5806, 9, false);
#line 135 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                                      Write(dep.Texto);

#line default
#line hidden
            EndContext();
            BeginContext(5815, 217, true);
            WriteLiteral("</p>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"dep-barra\"></div>\r\n                        </div>\r\n");
            EndContext();
#line 141 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(6074, 183, true);
            WriteLiteral("            </div>\r\n\r\n            <div class=\"dep-buttons flex-container\">\r\n              <button><a href=\"/Pagina/Home\">Voltar</a></button>\r\n            </div>\t\r\n        </section>\r\n");
            EndContext();
#line 149 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Depoimento\Listar.cshtml"
    }

#line default
#line hidden
            BeginContext(6264, 9, true);
            WriteLiteral("</main>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
