setlocal

cd /d %~dp0

set "startupFolder=%APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup"

set "shortcutName=dyfilm_stater.lnk"
set "targetPath=%~dp0dyfilm_stater.bat"

set "shortcutPath=%startupFolder%\%shortcutName%"

powershell -Command "$WshShell = New-Object -ComObject WScript.Shell; $Shortcut = $WshShell.CreateShortcut('%shortcutPath%'); $Shortcut.TargetPath = '%targetPath%'; $Shortcut.WorkingDirectory = '%~dp0'; $Shortcut.Save()"

pause
