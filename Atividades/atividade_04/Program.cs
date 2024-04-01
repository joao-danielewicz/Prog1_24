using atividade_04.Models;

TipoImovel TpImovel = new TipoImovel();
TpImovel.Id = 1;
TpImovel.NomeTipoImovel = "Casa";

TipoNegocio TpNegocio = new TipoNegocio();
TpNegocio.Id = 1;
TpNegocio.NomeTipoNegocio = "Venda";

Localidade Local = new Localidade();
Local.Id = 1;
Local.NomeTipoLocalidade = "Urbano";

Imovel Imovel01 = new Imovel();
Imovel01.Id = 1;
Imovel01.Nome = "Casa Amarela 2";
Imovel01.Descricao = "Ampla, arejada, bem localizada, dois andares.";
Imovel01.Valor = 875000;
Imovel01.QtdComodos = 6;
Imovel01.Localidade = Local;
Imovel01.TipoImovel = TpImovel;
Imovel01.TipoNegocio = TpNegocio;

Imagem Img = new Imagem();
Img.Id = 1;
Img.BytesImagem = null;
Img.Imovel = Imovel01;

Console.WriteLine(Img.Imovel.Nome);