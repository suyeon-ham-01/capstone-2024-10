using Fusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ILobbyController
{
    public void ShowLoadingMenu();

    public void PlayHover();

    public void ExitMenu();

    public void DestroyMenu();

    void OpenRoomCreate();

    void CloseRoomCreate();

    void CloseRoomJoin();

    void OpenRoomJoin(string sessionName, string password);
}
