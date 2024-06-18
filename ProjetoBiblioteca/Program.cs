using ProjetoLocadora.Models;
using ProjetoLocadora.Controllers;

// ItemController ic = new ItemController();

// Item item = new Item();
// ic.Insert(item);


// List<Item> list = ic.RetrieveAll();



// for (int j = 0; j < 10; j++){
//     Item item2 = new Item();
//     ic.Insert(item2);
// }

// banana();
// ic.Remove(Convert.ToInt32(Console.ReadLine()));

// item.Titulo="meu deus";
// ic.Update(item);
// banana();


// void banana(){
//     foreach (var i in list)
//     {
//         Console.WriteLine(i.ToString());
//     }
// }

// LocadoraController lc = new LocadoraController();

// Locadora locadora = new Locadora();
// lc.Insert(locadora);


// List<Locadora> list = lc.RetrieveAll();



// for (int j = 0; j < 10; j++){
//     Locadora locadora2 = new Locadora();
//     lc.Insert(locadora2);
// }

// banana();
// lc.Remove(Convert.ToInt32(Console.ReadLine()));

// locadora.Nome="meu deus";
// lc.Update(locadora);
// banana();


UsuarioController uc = new UsuarioController();

Usuario usuario = new Usuario();
uc.Insert(usuario);



List<Usuario> list = uc.RetrieveAll();



for (int j = 0; j < 10; j++){
    Usuario usuario2 = new Usuario();
    uc.Insert(usuario2);
}

banana();
uc.Remove(Convert.ToInt32(Console.ReadLine()));

usuario.Nome="meu deus";
uc.Update(usuario);
banana();


void banana(){
    foreach (var i in list)
    {
        Console.WriteLine(i.ToString());
    }
}