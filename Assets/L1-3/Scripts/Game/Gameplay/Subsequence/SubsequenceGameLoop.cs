using System;
using L1_3.Scripts.Game.Infrastructure.Gameplay;
using L1_3.Scripts.Game.Utilities.CoroutineManagement;
using L1_3.Scripts.Game.Utilities.SceneManagement;
using UnityEngine;

namespace L1_3.Scripts.Game.Gameplay.Subsequence
{
    public class SubsequenceGameLoop: IDisposable
    {
        private readonly SubsequenceHandler _subsequenceHandler;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly SubsequenceGameConditionProcessor _conditionProcessor;

        private readonly GameplaySceneContext _gameplaySceneContext;
        

        public SubsequenceGameLoop(
            SubsequenceHandler subsequenceHandler, 
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            SubsequenceGameConditionProcessor conditionProcessor,
            GameplaySceneContext gameplaySceneContext)
        {
            _subsequenceHandler = subsequenceHandler;
            _subsequenceHandler.Win += OnWin;
            _subsequenceHandler.Lose += OnLose;
            
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _conditionProcessor = conditionProcessor;
            
            _gameplaySceneContext = gameplaySceneContext;
        }

        public void Start(SubsequenceType subsequenceType) => Debug.Log(_subsequenceHandler.Generate(subsequenceType));

        public void Update()
        {
            if (_subsequenceHandler.IsCompleted && Input.GetKeyDown(KeyCode.Space))
            {
                _coroutinesPerformer.StartPerform(_sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplaySceneContext(_gameplaySceneContext.SubsequenceType)));
            }
            
            _subsequenceHandler.Tick();
        }
        
        public void Dispose()
        {
            _subsequenceHandler.Win -= OnWin;
            _subsequenceHandler.Lose -= OnLose;
        }

        private void OnWin()
        {
            _conditionProcessor.ProcessWin();
            Debug.Log("Нажмите Space для перезапуска");
        }

        private void OnLose()
        {
            _conditionProcessor.ProcessLose();
            Debug.Log("Нажмите Space для перезапуска");
        }
    }
}