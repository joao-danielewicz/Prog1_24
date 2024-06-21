﻿using ProjetoLocadora.Views;
using ProjetoLocadora.Models;
using ProjetoLocadora.Controllers;
using ProjetoLocadora.Utils;

Init();

static void Init(){
    bool aux = true;
    Texto txt = new();
    LocadoraController lc = new();
    string tituloMenu = "****** MENU PRINCIPAL - SISTEMA DE LOCADORAS ******";
    string[] menu = {
        "1 - Acessar locadora...",
        "2 - Importar dados básicos para teste",
        "0 - Sair"};

    do{
        try{
            Clear();
            txt.WriteMenu(tituloMenu, menu);
            int opcao = Convert.ToInt32(ReadLine());

            switch(opcao){
                case 1:
                    AcessoLocadora();
                    break;
                case 2:
                    
                    break;
                case 0:
                    aux = false;
                    break;
                default:
                    WriteLine("Opção inválida. Tente novamente.\n");
                    aux = true;
                    break;
            }
        }catch{
            WriteLine("Erro. Tente novamente.\n");
        }
    }while(aux);

    void AcessoLocadora(){
        if(lc.VerificarLocadoras()!=0){
            bool aux = true;
            do{
                WriteLine("Escolha uma das locadoras a seguir para realizar seu acesso.");
                WriteLine(string.Format(Locadora.Formato, "ID", "Nome", "", ""));
                foreach(var loc in lc.RetrieveAll()){
                    WriteLine(string.Format(Locadora.Formato, loc.LocadoraId, loc.Nome, "", ""));
                }
                try{
                    int locadoraId = Convert.ToInt32(ReadLine());
                    LocadoraView lv = new(locadoraId);
                }catch{
                    WriteLine("Houve um erro. Tente novamente.");
                }
            }while(aux);
        }else{
            WriteLine("Nenhuma locadora encontrada. Por favor, cadastre uma para começar.");
            LocadoraView lv = new();
        }
    }
}