#pragma checksum "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Usuario\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45c9622f67fb1bc535743588fb8ffa61606e31ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Login), @"mvc.1.0.view", @"/Views/Usuario/Login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Usuario/Login.cshtml", typeof(AspNetCore.Views_Usuario_Login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45c9622f67fb1bc535743588fb8ffa61606e31ca", @"/Views/Usuario/Login.cshtml")]
    public class Views_Usuario_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Usuario\Login.cshtml"
  
    ViewBag.Title = "Login";
    Layout = "MasterPageCadastroLogin";

#line default
#line hidden
            BeginContext(78, 588, true);
            WriteLiteral(@"
<div class=""box"">
    <div class=""container-lr left""></div>
            
    <div class=""main"">
        <div class=""meio-circulo""></div>
                
        <div class=""container"">
            <div class=""header-logo"">
                    <img src=""/imagem/logo.png"" alt=""logotipo CarFel"" class=""logo"">
            </div>
            <div class=""header-titulo"">
                    <h1>Login</h1>
            </div>
            <div class=""form-main"">
                <div class=""mensagem"" style=""margin: 0 0 0.5em 0;"">
                    <p class=""mensegeInvalid"">");
            EndContext();
            BeginContext(667, 19, false);
#line 21 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Usuario\Login.cshtml"
                                         Write(TempData["AuthDep"]);

#line default
#line hidden
            EndContext();
            BeginContext(686, 278, true);
            WriteLiteral(@"</p>                
                </div>
                
                <form method=""post"" action=""/Usuario/Login"" class=""formulario flex-container"">
                    <label>
                        <p>Email:</p>
                        <p class=""mensegeInvalid"">");
            EndContext();
            BeginContext(965, 24, false);
#line 27 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Usuario\Login.cshtml"
                                             Write(TempData["MensengeValE"]);

#line default
#line hidden
            EndContext();
            BeginContext(989, 271, true);
            WriteLiteral(@"</p>
                        <input type=""email"" name=""email"" required class=""form-input"">
                    </label>
                            
                    <label>
                        <p>Senha:</p>
                        <p class=""mensegeInvalid"">");
            EndContext();
            BeginContext(1261, 24, false);
#line 33 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Usuario\Login.cshtml"
                                             Write(TempData["MensengeValS"]);

#line default
#line hidden
            EndContext();
            BeginContext(1285, 357, true);
            WriteLiteral(@"</p>
                        <input type=""password"" name=""senha"" required class=""form-input"">
                    </label>
                        
                    <input type=""submit"" name=""enviar"" value=""Entrar"" class=""form-button"">
                </form>

                <div class=""mensagem"">
                    <p class=""mensegeInvalid"">");
            EndContext();
            BeginContext(1643, 24, false);
#line 41 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Usuario\Login.cshtml"
                                         Write(TempData["MensValLogin"]);

#line default
#line hidden
            EndContext();
            BeginContext(1667, 631, true);
            WriteLiteral(@"</p>                
                </div>

                <div class=""main-lr-item"">
                    <p>Não possui uma conta? <a href=""/Usuario/Cadastrar"">Cadastre-se</a></p>
                </div>

                <div class=""sair"">
                    <a href=""/Pagina/Home"">Sair</a>
                </div>
            </div>
        </div>
    </div>
            
    <div class=""container-lr"">
        <div class=""lr-item"">
            <p>Não possui uma conta?</p>
            <button class=""form-button bt-login""><a href=""/Usuario/Cadastrar"">Cadastre-se</a></button>
        </div>
    </div>
</div>");
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
