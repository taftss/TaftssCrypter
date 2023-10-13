

<p align="center">
 <img src="https://github.com/taftss/TaftssCrypter/blob/master/TaftssCrypter.png" alt="alt text" >  
</p>

# TaftssCrypter

TaftssCrypter is a C# application developed to measure the resilience of security products against ransomware attacks. TaftssCrypter is designed to simulate ransomware attacks and perform customized ransomware simulations

<b>Notice: This tool is developed exclusively for simulations. Please do not use it for illegal activities !</b>

### Features

- It encrypts the desired folder and its subfolders in a target-based manner.
- It encrypts the desired file extensions. It encrypts all files within a folder or specifically specified files.
- It operates on a user-based level, taking user information parametrically and working within the scope of permissions.
- It can be used with C2s like Cobalt Strike using 'execute-assembly'.
- It can perform encryption and decryption processes.
- It enables realistic ransomware attack simulations using the AES256 algorithm.
- You can encrypt all files in the target folder, including subfolders, using "\*.\*"

### Usage
TaftssCrypter takes 4 different parameters. It operates by receiving a mode selection parameter and 3 target information parameters. The 3 target parameters are indicated with double quotation marks.

The first parameter specifies the target file path. The second parameter specifies the username under which processes are executed (as obtained from the 'whoami' command output). The third parameter specifies the file extensions to be indicated in the form of \*.\* ("\*.\*" or "*.txt"for example).

| Paramater | Description                    |
| ------------- | ------------------------------ |
| `-e`      | Encrypter Mode.       |
| `-d`   | Dencrypter Mode.      |
| `First "" Parameter`   | Target Folder Full Path. For example "C:\\\"      |
| `Second "" Parameter`   | The hostname and username where the process is executed. You can use the output of the 'Whoami' command.     |
| `Third "" Parameter`   | Target File Extensions. For example "\*.\*" or "*.txt,*.docx... etc"      |


### Command & Control Usage
TaftssCrypter is developed as a .NET assembly that can be executed via a command and control center, making it compatible with red team simulations like Cobalt Strike. It seamlessly handles both encryption and decryption operations.

![Command & Control](https://github.com/taftss/TaftssCrypter/blob/master/TaftssCrypter%20C2.png)

### Encrypter Usage
`TaftssCrypter.exe -e "[Target Folder Path]" "[host/username]" "*.[TargetExtensions], *.[TargetExtensions],....,*.[TargetExtensions]"`

![Before Encryption](https://github.com/taftss/TaftssCrypter/blob/master/TaftssCrypter%20E1.png)

![After Encryption](https://github.com/taftss/TaftssCrypter/blob/master/TaftssCrypter%20E2.png)

### Decrypter Usage
`TaftssCrypter.exe -d "[Target Folder Path]" "[host/username]" "*.[TargetExtensions], *.[TargetExtensions],....,*.[TargetExtensions]"`

![Before Decryption](https://github.com/taftss/TaftssCrypter/blob/master/TaftssCrypter%20D1.png)

![After Decryption](https://github.com/taftss/TaftssCrypter/blob/master/TaftssCrypter%20D2.png)
