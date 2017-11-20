#define Version ReadIni(SourcePath + "\config.ini", "Install", "Version")
#define SafeVersion ReadIni(SourcePath + "\config.ini", "Install", "SafeVersion")
#define ApplicationName "Youtube Controller"
#define ExeName "Gh61.Youtube.Controller.Win.exe"


[Setup]
AppId={{3e7d501c-a894-4494-8e94-1c3c5c1bf873}
AppName={#ApplicationName}
AppVersion={#Version}
AppPublisher=Gh61
AppPublisherURL=https://github.com/Gh61/
AppSupportURL=https://github.com/Gh61/youtube-chrome-controller
DefaultDirName={pf}\{#ApplicationName}
OutputBaseFilename= "youtube_controller_{#SafeVersion}"
Compression=lzma
SolidCompression=yes
DisableProgramGroupPage=true
SetupIconFile=setup_icon.ico
MinVersion=6.0


[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: Source\*; Excludes: ".gitignore"; DestDir: {app}; Flags: ignoreversion

[Icons]
Name: "{userdesktop}\{#ApplicationName}"; Filename: "{app}\{#ExeName}"; Tasks: desktopicon

#include "code.iss"