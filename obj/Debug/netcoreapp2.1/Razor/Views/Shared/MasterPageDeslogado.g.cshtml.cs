#pragma checksum "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Shared\MasterPageDeslogado.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49c096511c50fe34877cd7a5ddbc4637c4561f18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_MasterPageDeslogado), @"mvc.1.0.view", @"/Views/Shared/MasterPageDeslogado.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/MasterPageDeslogado.cshtml", typeof(AspNetCore.Views_Shared_MasterPageDeslogado))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49c096511c50fe34877cd7a5ddbc4637c4561f18", @"/Views/Shared/MasterPageDeslogado.cshtml")]
    public class Views_Shared_MasterPageDeslogado : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 38, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"pt-br\">\r\n");
            EndContext();
            BeginContext(38, 538, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d00baa80e8645659ecd5dde6ef4dca8", async() => {
                BeginContext(44, 500, true);
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <link href=""https://fonts.googleapis.com/css?family=Montserrat"" rel=""stylesheet"">
	<link href=""http://fonts.googleapis.com/icon?family=Material+Icons"" rel=""stylesheet"">
    <link type=""text/css"" rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/css/materialize.min.css""/>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0""/>
	<link rel=""stylesheet"" type=""text/css"" href=""/css/estilos.css"">
	<title>CarFel - ");
                EndContext();
                BeginContext(545, 13, false);
#line 10 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Shared\MasterPageDeslogado.cshtml"
               Write(ViewBag.Title);

#line default
#line hidden
                EndContext();
                BeginContext(558, 11, true);
                WriteLiteral(" </title>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(576, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(578, 2346, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "db7abab0d01445509f355334f5e706ae", async() => {
                BeginContext(584, 1402, true);
                WriteLiteral(@"
    <script src=""https://code.jquery.com/jquery-2.1.1.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/materialize/0.98.0/js/materialize.min.js""></script>
    
	<header>
		<nav>
			<div class=""nav-wrapper"">
				<!-- <img class=""logo-img"" src=""imagem/logo.png"" alt=""Logo da empresa CarFel"">	 -->
				<a href=""#"" data-activates=""menu-mobile"" class=""button-collapse"">
					<i class=""material-icons"">menu</i>
				</a>
				<script>
				$(function(){
					$("".button-collapse"").sideNav();
				});
				</script>
				<ul class=""right hide-on-med-and-down"">
					<li><a href=""/Pagina/Home"">Home</a></li>
					<li><a href=""/Pagina/Empresa"">Sobre Nós</a></li>
					<li><a href=""/Pagina/Precos"">Preçõs</a></li>
					<li><a href=""/Pagina/Contato"">Contato</a></li>
					<li><a href=""/Depoimento/Listar"">Depoimentos</a></li>
					<li><a href=""/Usuario/Login"">Login</a></li>
					<li><a href=""/Usuario/Cadastrar"">Cadastrar-se</a></li>
				</ul>
				
				<ul class=""class side-nav"" id=""men");
                WriteLiteral(@"u-mobile"">
					<li><a href=""/Pagina/Home"">Home</a></li>
					<li><a href=""/Pagina/Empresa"">Sobre Nós</a></li>
					<li><a href=""/Pagina/Precos"">Preçõs</a></li>
					<li><a href=""/Pagina/Contato"">Contato</a></li>
					<li><a href=""/Depoimento/Listar"">Depoimentos</a></li>
					<li><a href=""/Usuario/Login"">Login</a></li>
				</ul>
			</div>
		</nav>
	</header>

    ");
                EndContext();
                BeginContext(1987, 12, false);
#line 50 "C:\Users\50473694808\Desktop\Projeto CarFel\Projeto-CarFel-CkeckPoint-Web\Views\Shared\MasterPageDeslogado.cshtml"
Write(RenderBody());

#line default
#line hidden
                EndContext();
                BeginContext(1999, 918, true);
                WriteLiteral(@"

    <footer class=""flex-container"">
    	<ul>
			<a href=""/Pagina/Home"">
				<li class=""footer-item"">Home</li>
				<li>CheckPoint</li>
				<li>Termos de uso</li>
				<li>Suporte</li>
				<li>Chat</li>
			</a>
        </ul>
        <ul>
			<a href=""/Pagina/Empresa"">
				<li class=""footer-item"">Institucional</li>
				<li>Sobre Nós</li>
				<li>História</li>
				<li>Outros produtos</li>
				<li>Colaboradores</li>
			</a>
        </ul>
        <ul>
			<a href=""/Pagina/Contato"">
				<li class=""footer-item""> Contato</li>
				<li>(XX) XXXXX-XXXX</li>
				<li>carfel.checkpoint@gmail.com</li>
				<li>Alameda Barão de Limeira, 539 </li>
				<li>Santa Cecilia</li>
			</a>
        </ul>
        <ul>
            <li class=""footer-item"">Siga-nós</li>
            <img src=""/imagem/redessociais.png"" alt=""Icones das redes sociais."" width=""170"" height=""170"">
        </ul>
    </footer>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2924, 9, true);
            WriteLiteral("\r\n</html>");
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
