SDB Profiles (Compatibility fixes)
=====================
This repository contains SDB profiles, also often called Compatibility fixes for various different games. All of these were created by me, using Compatibility Administrator.

Installation
-------
To add SDB profile to your system, create a *.cmd or *.bat file under whatever name you want.
Edit it and type in:
>%WINDIR%\System32\sdbinst.exe -q "**path**"

where **path** is a path to an SDB file you want to install (can be both absolute and relative). E.g.:
>%WINDIR%\System32\sdbinst.exe -q "fix.sdb"

Save it. Right click on the file and start is as administrator.

Uninstallation
-------
Uninstalling SDB profiles is done identical to installing them. You create a CMD file, you edit it, except you type in:
>%WINDIR%\System32\sdbinst.exe -u -q "**path**"

Same rules apply (either relative path or absolute).
>%WINDIR%\System32\sdbinst.exe -u -q "fix.sdb"

It should also be possible to uninstall them using **Programs and functions** in your Windows Control Panel.