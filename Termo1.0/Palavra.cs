using System.Diagnostics.Eventing.Reader;

namespace Termo1._0
{
    public class Palavra
    {
        public string palavraSecreta = "";
        public string palavraSecretaComAcento = "";
        public Palavra() 
        {
            SortearPalavraSecreta();
        }

        public void SortearPalavraSecreta()
        {
            string[] palavras = new string[]
            {
                "acido", "adiar", "impar", "algar", "amado", "amigo", "anexo", "anuir", "aonde", "apelo",
                "aquem", "argil", "arroz", "assar", "atras", "avido", "azeri", "babar", "bagre", "banho", "barco",
                "bicho", "bolor", "brasa", "brava", "brisa", "bruto", "bulir", "caixa", "cansa", "chato", "chave",
                "chefe", "choro", "chulo", "claro", "cobre", "corte", "curar", "deixo", "dizer", "dogma", "dores",
                "duque", "enfim", "estou", "exame", "falar", "fardo", "farto", "fatal", "feliz", "ficar", "fogue",
                "forca", "forno", "fraco", "fugir", "fundo", "furia", "gaita", "gasto", "geada", "gelar", "gosto",
                "grito", "gueto", "honra", "humor", "idade", "ideia", "idolo", "igual", "imune", "indio", "ingua",
                "irado", "isola", "janta", "jovem", "juizo", "largo", "laser", "leite", "lento", "lerdo", "levar",
                "lidar", "lindo", "lirio", "longe", "luzes", "magro", "maior", "malte", "mamar", "manto", "marca",
                "matar", "meigo", "meios", "melao", "mesmo", "metro", "mimos", "moeda", "moita", "molho", "morno",
                "morro", "motim", "muito", "mural", "naipe", "nasci", "natal", "naval", "ninar", "nivel", "nobre",
                "noite", "norte", "nuvem", "oeste", "ombro", "ordem", "orgao", "osseo", "ossos", "outro", "ouvir",
                "palma", "pardo", "passe", "patio", "peito", "pelos", "perdo", "peril", "perto", "pezar", "piano",
                "picar", "pilar", "pingo", "pione", "pista", "poder", "porem", "prado", "prato", "prazo", "preco",
                "prima", "primo", "pular", "quero", "quota", "raiva", "rampa", "rango", "reais", "reino", "rezar",
                "risco", "rocar", "rosto", "roubo", "russo", "saber", "sacar", "salto", "samba", "santo", "selar",
                "selos", "senso", "sera", "serra", "servo", "sexta", "sinal", "sobra", "sobre", "socio", "sorte", 
                "subir", "sujei", "sujos", "talao","talha", "tanga", "tarde", "tempo", "tenho", "terco", "terra",
                "tesao", "tocar", "lacre", "laico", "lamba", "lambo", "largo", "larva", "lasca", "laser", "laura",
                "lavra", "leigo", "leite", "leito", "leiva", "lenho", "lento", "leque", "lerdo", "lesao", "lesma",
                "levar", "libra", "limbo", "lindo", "lineo", "lirio", "lisar", "lista", "livro", "logar", "lombo",
                "lotes", "louca", "louco", "louro", "lugar", "luzes", "macio", "macon", "maior", "malha", "malte",
                "mamar", "mamae", "manto", "marco", "maria", "marra", "marta", "matar", "medir", "meigo", "meios",
                "melao", "menta", "menti", "mesmo", "metro", "miado", "midia", "mielo", "mielo", "milho", "mimos", 
                "minar"
            };

            int i = new Random().Next(0, palavras.Length - 1);
            this.palavraSecreta = palavras[0].ToUpper();
            this.palavraSecretaComAcento = palavras[0];

        }

        internal AvaliacaoLetra[] Avaliar(string palavraChute)
        {
            AvaliacaoLetra[] avaliacoes = new AvaliacaoLetra[palavraChute.Length];

            for(int i = 0; i < palavraChute.Length; i++) 
            {
                if (palavraChute[i] == palavraSecreta[i])
                {
                    avaliacoes[i] = AvaliacaoLetra.Correta;
                }
                else if (palavraSecreta.Contains(palavraChute[i]))
                {
                    avaliacoes[i] = AvaliacaoLetra.PosicaoIncorreta;
                }
                else
                    avaliacoes[i] = AvaliacaoLetra.NaoExistente;

            }

            return avaliacoes;
        }
    }
}