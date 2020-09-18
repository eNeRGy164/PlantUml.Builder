# Implemented commands

Following the PlantUML source code.

## Common commands

| Command            | Implemented |
| ------------------ | ----------- |
| ' [\<COMMENT>]     | yes         |
| /' [\<COMMENT>] '/ | yes         |

## Activity Diagrams
| Command                                  | Implemented |
| ---------------------------------------- | ----------- |
| start;                                   | no          |
| end;                                     | no          |
| [\<COLOR>] [\<STEREO>] :\<LABEL>\<STYLE> | no          |
| [-[\<COLOR>,\<LINESTYLE>]]-> [\<LABEL>]; | no          |
| fork;                                    | no          |
| fork again;                              | no          |
| end fork [{\<LABEL>}];                   | no          |

## Class Diagrams
| Command                                                                                                                                                                                             | Implemented |
| --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------- |
| [\<VISIBILITY>] interface \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]      | yes         |
| [\<VISIBILITY>] enum \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]           | yes         |
| annotation \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>]  [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                    | no          |
| [\<VISIBILITY>] abstract class \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]] | yes         |
| [\<VISIBILITY>] abstract \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]       | no          |
| [\<VISIBILITY>] class \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]          | yes         |
| [\<VISIBILITY>] entity \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]         | yes         |
| circle \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                         | no          |
| diamond \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                        | no          |
| hide [\<NAME>] [empty] \<PORTION>                                                                                                                                                                   | yes         |
| show [\<NAME>] [empty] \<PORTION>                                                                                                                                                                   | no          |
| hide \<VISIBILITY>[,\<VISIBILITY>*] \<PORTION>                                                                                                                                                      | yes         |
| show \<VISIBILITY>[,\<VISIBILITY>*] \<PORTION>                                                                                                                                                      | no          |
| set namespaceseparator \<SEPARATOR>                                                                                                                                                                 | yes         |

## Sequence Diagrams

| Command                                                  | Implemented |
| -------------------------------------------------------- | ----------- |
| activate \<WHO> [\<BACK>] [\<LINE>]                      | yes         |
| deactivate \<WHO>                                        | yes         |
| deactivate \<WHO> [\<BACK>] [\<LINE>]                    | no          |
| deactivate                                               | yes         |
| destroy \<WHO> [\<BACK>] [\<LINE>]                       | no          |
| create \<WHO> [\<BACK>] [\<LINE>]                        | no          |
| \<NAME>++ [\<COLOR>]                                     | no          |
| \<NAME>-- [\<COLOR>]                                     | no          |
| autonewpage                                              | no          |
| autoactivate off\|on                                     | no          |
| autonumber \<START> \<STEP> \<FORMAT>                    | no          |
| autonumber inc                                           | no          |
| autonumber resume [\<FORMAT>]                            | no          |
| autonumber stop                                          | no          |
| end box                                                  | yes         |
| box [\<NAME>] [\<STEREO>] [\<COLOR>]                     | partial     |
| delay [\<LABEL>]                                         | yes         |
| divider [\<LABEL>]                                       | yes         |
| hide footbox                                             | no          |
| show footbox                                             | no          |
| opt [\<COLOR>] [\<COMMENT>]                              | no          |
| alt [\<COLOR>] [\<COMMENT>]                              | partial     |
| loop [\<COLOR>] [\<COMMENT>]                             | no          |
| par [\<COLOR>] [\<COMMENT>]                              | no          |
| par2 [\<COLOR>] [\<COMMENT>]                             | no          |
| break [\<COLOR>] [\<COMMENT>]                            | no          |
| critical [\<COLOR>] [\<COMMENT>]                         | no          |
| else [\<COLOR>] [\<COMMENT>]                             | partial     |
| end [\<COLOR>] [\<COMMENT>]                              | no          |
| also [\<COLOR>] [\<COMMENT>]                             | no          |
| group [\<COLOR>] [\<COMMENT>]                            | partial     |
| hspace                                                   | yes         |
| ignore newpage                                           | no          |
| newpage [\<LABEL>]                                       | no          |
| participant \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>] | partial     |
| actor \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]       | partial     |
| boundary \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]    | partial     |
| control \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]     | partial     |
| entity \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]      | partial     |
| queue \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]       | partial     |
| database \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]    | partial     |
| collections \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>] | partial     |
| ref[\<COLOR>] over \<NAME> : [\<URL>] [\<TEXT>]          | no          |
| return [\<COLOR>] \<MESSAGE>                             | no          |
