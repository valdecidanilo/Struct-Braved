using System.IO;
using Braved.Manager;
using Braved.Views;
using Braved.Controllers;
using UnityEditor;
using UnityEngine;
using Component = Braved.Components.Component;

namespace Braved.Editor
{
    public class CreateFolders : MonoBehaviour
    {
        private const string BasePath = "Assets/";
        private const string ScriptsPath = "Assets/Scripts";
        
        private const string ManagerPath = ScriptsPath + "/Manager";
        private const string ControllersPath = ScriptsPath + "/Controllers";
        private const string ViewsPath = ScriptsPath + "/Views";
        private const string ComponentsPath = ScriptsPath + "/Components";
    
        [MenuItem("Braved/Structure/Create Structure")]
        private static void CreateProjectStructure()
        {
            // Criação de pastas principais
            CreateFolder($"{BasePath}/Animator");
            CreateFolder($"{BasePath}/Resources");
            CreateFolder($"{BasePath}/Prefabs");
            CreateFolder($"{BasePath}/Sprites");
            CreateFolder($"{BasePath}/Scripts");
            CreateFolder($"{BasePath}/AssetBundles");
    
            // Criação de subpastas dentro de Scripts
            CreateFolder($"{ScriptsPath}/Manager");
            CreateFolder($"{ScriptsPath}/Components");
            CreateFolder($"{ScriptsPath}/Controllers");
            CreateFolder($"{ScriptsPath}/Interfaces");
            CreateFolder($"{ScriptsPath}/Manager");
            CreateFolder($"{ScriptsPath}/Models");
            CreateFolder($"{ScriptsPath}/Services");
            CreateFolder($"{ScriptsPath}/States");
            CreateFolder($"{ScriptsPath}/Utils");
            CreateFolder($"{ScriptsPath}/Views");
    
            Debug.Log("Estrutura do projeto criada com sucesso!");
            
            CreateScriptsAddressables();
        }
        private static void CreateScriptsAddressables()
        {
            
            CreateScript<Controller>("Home", ControllersPath, @"
using Scripts.Views;
using Braved.Interfaces;
using UnityEngine;

namespace Scripts.Controllers
{
    public class HomeController : MonoBehaviour, IController
    {
        // Todo controlador deve ter uma referência (canvas) para a view
        public Transform canvas;
        // Todo controlador deve ter uma referência para a view
        private HomeView _view;
        private Coroutine _coroutine;
        
        private void Awake()
        {
            // Caso necessite fazer alguma operação antes de iniciar a view
        }
        public void StartController()
        {
            // Inicia a view
            _view = new HomeView(canvas);
        }
    }
}            
");
            
            CreateScript<View>("Home", ViewsPath,@"
using Braved.Interfaces;
using Scripts.Components;
using UnityEngine;
//using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.AsyncOperations;
using Utils;

namespace Scripts.Views
{
    public class HomeView : IView
    {
        private HomeComponent _component;
        
        public HomeView(Transform parent)
        {
            /* Criação do componente com Addressable
            var asset = new AssetReference(""HomeView"");
            var handle = asset.InstantiateAsync(parent);
            handle.Completed += OnComplete;
            */
        }

        private void OnComplete(/*AsyncOperationHandle<GameObject> obj*/)
        {
            // Verifica se a operação foi bem sucedida
            /*
            if (obj.Status != AsyncOperationStatus.Succeeded) return;
            var instantiatedObject = obj.Result;
            _component = instantiatedObject.GetComponent<HomeComponent>();
            */
            /* Inicializa os componentes
            _component.ButtonOk.onClick.AddListener(() =>
            {
                Debug.Log(""Ok"");
            });
            */
        }
        public void Unload()
        {
            // Tira o componente da memória e destroi o objeto
            //Addressables.ReleaseInstance(_component.gameObject);
        }
    }
}
");
            CreateScript<Component>("Home", ComponentsPath, @"
//using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Components
{
    public class HomeComponent : MonoBehaviour
    {
        /*
            Todas as referencias de componentes devem ser feitas aqui
        */
        //public Button ButtonOk;
        //public TMP_Text Text;
        /* Caso necessite de operações pode se usar para atribuir valores
            public void SetText(string text)
            {
                Text.text = text;
            }
        */
    }
}
");
            CreateScript<GameManager>("", ManagerPath, @"
using Scripts.Controllers;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        // Todos so controladores devem ser referenciados aqui
        public HomeController controller;
        
        private void Awake()
        {
            controller.StartController();
        }
        private void UnloadUnusedAssets()
        {
            // Limpa a memória, chame sempre que necessário.
            Resources.UnloadUnusedAssets();
        }
    }
}
");
            
            AssetDatabase.Refresh();
            Debug.Log("Scripts criados com sucesso!");
        }

        private static void CreateScript<T>(string name, string path, string bodytemplate) where T : class
        {
            var scriptName = name + typeof(T).Name + ".cs";
            var scriptPath = Path.Combine(path, scriptName);

            // Verifica se o script já existe na pasta
            if (AssetDatabase.LoadAssetAtPath(scriptPath, typeof(MonoScript))) return;
    
            // Cria o script na pasta especificada
            var template = GetScriptTemplate(typeof(T), name, bodytemplate);
    
            // Certifique-se de criar o diretório do script se ainda não existir
            Directory.CreateDirectory(path);
    
            // Adiciona manualmente o nome do arquivo do script ao caminho
            scriptPath = Path.Combine(path, scriptName);
    
            File.WriteAllText(scriptPath, template);
            AssetDatabase.Refresh();
        }
        private static string GetScriptTemplate(System.Type type, string className, string bodytemplate)
        {
            // Aqui você pode personalizar o modelo do script conforme necessário
            string baseTypeName;
            if (type.BaseType != null && type.BaseType != typeof(object) && type.BaseType.Name != "ValueType")
            {
                baseTypeName = type.BaseType.Name;
            }
            else
            {
                // Se a classe não herdar de MonoBehaviour, use diretamente o nome da classe
                baseTypeName = type.Name;
            }

            return bodytemplate;
        }
        private static void CreateFolder(string path)
        {
            // Verifica se a pasta não existe antes de criar
            if (!AssetDatabase.IsValidFolder(path))
            {
                AssetDatabase.CreateFolder(Path.GetDirectoryName(path), Path.GetFileName(path));
            }
        }
    }
}
