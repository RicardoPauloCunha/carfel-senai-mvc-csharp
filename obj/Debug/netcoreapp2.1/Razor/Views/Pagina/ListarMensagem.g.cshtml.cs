#pragma checksum "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a7dfcdc23c50a2d394efe91d759ea431d248d81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pagina_ListarMensagem), @"mvc.1.0.view", @"/Views/Pagina/ListarMensagem.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pagina/ListarMensagem.cshtml", typeof(AspNetCore.Views_Pagina_ListarMensagem))]
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
#line 1 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
using Projeto_CarFel_CkeckPoint_Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a7dfcdc23c50a2d394efe91d759ea431d248d81", @"/Views/Pagina/ListarMensagem.cshtml")]
    public class Views_Pagina_ListarMensagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
  
    ViewBag.Title = "Contato";
    if (this.ViewBag.UserLog == null)
    {
        Layout = "MasterPageDeslogado";
    }
    else
    {
        Layout = "MasterPageLogado";    
    }

#line default
#line hidden
            BeginContext(245, 263, true);
            WriteLiteral(@"
<div class=""titulo flex-container"">
    <div class=""titulo-item"">
        <h2>Contato</h2>
    </div>
</div>

<main>
    <section class=""depoimentos depoimentos-pag espacamento"">
        <h2>Mensagens Recebidas</h2>
        <div class=""Usuarios-dep"">
");
            EndContext();
#line 24 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
              
                List<MensagemModel> lista = ViewData["Mensagens"] as List<MensagemModel>;
            

#line default
#line hidden
            BeginContext(630, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 27 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
             for (int i = lista.Count-1; i > 0; i--)
            {

#line default
#line hidden
            BeginContext(699, 309, true);
            WriteLiteral(@"                <div class=""user-dep"">
                    <div class=""flex-container"">
                        <div class=""dep-container"">
                            <div class=""dep-header flex-container"">
                                <div class=""dh-text"">
                                    <p><b>");
            EndContext();
            BeginContext(1009, 13, false);
#line 34 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
                                     Write(lista[i].Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1022, 49, true);
            WriteLiteral("</b></p>\r\n                                    <p>");
            EndContext();
            BeginContext(1072, 14, false);
#line 35 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
                                  Write(lista[i].Email);

#line default
#line hidden
            EndContext();
            BeginContext(1086, 45, true);
            WriteLiteral("</p>\r\n                                    <p>");
            EndContext();
            BeginContext(1132, 20, false);
#line 36 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
                                  Write(lista[i].DataCriacao);

#line default
#line hidden
            EndContext();
            BeginContext(1152, 206, true);
            WriteLiteral("</p>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"dep-main\">\r\n                                <p class=\"mensagem-assunto\">Assunto: <b>");
            EndContext();
            BeginContext(1359, 16, false);
#line 40 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
                                                                   Write(lista[i].Assunto);

#line default
#line hidden
            EndContext();
            BeginContext(1375, 45, true);
            WriteLiteral("</b></p>\r\n                                <p>");
            EndContext();
            BeginContext(1421, 14, false);
#line 41 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
                              Write(lista[i].Texto);

#line default
#line hidden
            EndContext();
            BeginContext(1435, 373, true);
            WriteLiteral(@"</p>
                            </div>
                            <div class=""dep-footer flex-container"">
								<div class=""df-reprovado"">
									<button><a href=""#"">Responder</a></button>
								</div>
							</div>
                        </div>
                    </div>
                    <div class=""dep-barra""></div>
                </div>       
");
            EndContext();
#line 52 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
            }

#line default
#line hidden
            BeginContext(1823, 203, true);
            WriteLiteral("        </div>\r\n    </section>\r\n\r\n    <section class=\"contato flex-container espacamento\">\r\n        <div class=\"contato-item\">\r\n            <h1>Entrar em contato</h1>\r\n            <div>\r\n                ");
            EndContext();
            BeginContext(2027, 24, false);
#line 60 "C:\Users\7\Desktop\Senai\Projeto-CarFel-CkeckPoint-Web\Views\Pagina\ListarMensagem.cshtml"
           Write(TempData["valCadastrar"]);

#line default
#line hidden
            EndContext();
            BeginContext(2051, 1910, true);
            WriteLiteral(@"
                <form method=""post"" action=""/Pagina/Contato"" class=""contato-item-form"">
                    <input type=""text"" name=""nome"" placeholder=""Nome:"" class=""contato-item-form-input"">
                    <input type=""email"" name=""email"" placeholder=""E-mail:"" class=""contato-item-form-input"">
                    <input type=""text"" name=""assunto"" placeholder=""Assunto:"" class=""contato-item-form-input"">
                    <textarea name=""texto"" placeholder=""Mensagem:"" class=""contato-item-form-input contato-textarea""></textarea>
                    <div class=""botao-contato"">
                        <input type=""submit"" value=""Enviar"" class=""button-sub"">
                    </div>
                </form>   
            </div>
        </div>
        
        <div class=""contato-item-dados"">
            <h2>CarFel</h2>
            <h3>Endereço:</h3>
            <p>Alameda Barão de Limeira, 539</p>
            <p>Santa Cecilia</p>
            <p>SAC XXXXXXXXX</p>
            <h3>Telefone:<");
            WriteLiteral(@"/h3>
            <p>(xx) XXXXX-XXXX</p>
            <h3>E-mail:</h3>
            <p>carfel.checkpoint@gmail.com</p>
            <h3>Redes Sociais</h3>
            <img src=""/imagem/redessociais.png"" alt=""Icones das redes sociais."" width=""170"" height=""170"">
        </div>
    </section>

    <section class=""mapa"">
        <div class=""mapa-img"">
            <h2>Como Chegar</h2>
            <iframe src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3657.8871329131534!2d-46.64847708510331!3d-23.53656156656186!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ce5843deade6e3%3A0x124f377d06c7e71f!2sAlameda+Bar%C3%A3o+de+Limeira%2C+539+-+Campos+El%C3%ADseos%2C+S%C3%A3o+Paulo+-+SP%2C+01202-001!5e0!3m2!1spt-BR!2sbr!4v1536842153722"" width=""600"" height=""450"" frameborder=""0"" style=""border:0"" allowfullscreen></iframe>
        </div>
    </section>
    
</main>");
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
