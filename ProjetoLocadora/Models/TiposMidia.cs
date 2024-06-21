namespace ProjetoLocadora.Models{
    // O decorador ushort força que os tipos de mídia sejam lidos como inteiros,
    // permitindo uma facilidade no armazenamento dos dados em um arquivo .txt, bem como sua conversão em objetos.
    public enum TiposMidia : ushort{
        None,
        Filme,
        Serie,
        Documentario,
        Novela
    }
}