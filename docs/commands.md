# Implemented commands

Following the PlantUML source code.

## Diagram commands

| Command                 | Implemented | Method            |
| ----------------------- | ----------- | ----------------- |
| @startuml [\<FILENAME>] | yes         | `UmlDiagramStart` |
| @enduml                 | yes         | `UmlDiagramEnd`   |

## Common commands

| Command                             | Implemented | Method         |
| ----------------------------------- | ----------- | -------------- |
| \<TEXT>                             | yes         | `Text`         |
| ' [\<COMMENT>]                      | yes         | `Comment`      |
| /' [\<COMMENT>] '/                  | yes         | `CommentBlock` |
| [\<ALIGN>] header \<HEADER>         | partial     | `Header`       |
| [\<ALIGN>] footer \<FOOTER>         | partial     | `Footer`       |
| [\<ALIGN>] header                   | no          |                |
| endheader                           | no          |                |
| [\<ALIGN>] footer                   | no          |                |
| endfooter                           | no          |                |
| scale [max] \<SCALE> [\<DIMENSION>] | no          |                |
| title \<TITLE>                      | yes         | `Title`        |
| title                               | no          |                |
| end title                           | no          |                |
| caption \<CAPTION>                  | no          |                |
| legend [\<ALIGN>]                   | no          |                |
| endlegend                           | no          |                |

## Activity Diagrams
| Command                                  | Implemented | Method |
| ---------------------------------------- | ----------- | ------ |
| start;                                   | no          |        |
| end;                                     | no          |        |
| [\<COLOR>] [\<STEREO>] :\<LABEL>\<STYLE> | no          |        |
| [-[\<COLOR>,\<LINESTYLE>]]-> [\<LABEL>]; | no          |        |
| fork;                                    | no          |        |
| fork again;                              | no          |        |
| end fork [{\<LABEL>}];                   | no          |        |

## Class Diagrams
| Command                                                                                                                                                                                                 | Implemented | Method                  |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------- | ----------------------- |
| interface \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                          | yes         | `Interface`             |
| [\<VISIBILITY>] interface \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]] {        | yes         | `InterfaceStart`        |
| }                                                                                                                                                                                                       | yes         | `InterfaceEnd`          |
| enum \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                               | yes         | `Enum`                  |
| [\<VISIBILITY>] enum \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]] {             | yes         | `EnumStart`             |
| }                                                                                                                                                                                                       | yes         | `EnumEnd`               |
| annotation \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>]  [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                        | no          |                         |
| [abstract] class \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                   | yes         | `Class`                 |
| [\<VISIBILITY>] [abstract] class \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]] { | yes         | `ClassStart`            |
| }                                                                                                                                                                                                       | yes         | `ClassEnd`              |
| entity \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                             | yes         | `Entity`                |
| [\<VISIBILITY>] entity \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]] {           | yes         | `EntityStart`           |
| }                                                                                                                                                                                                       | yes         | `EntityEnd`             |
| circle \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                             | no          |                         |
| diamond \<NAME> [as \<DISPLAY>] [\<GENERIC>] [\<STEREO>] [\<TAGS>] [\<URL>] [\<BACK>] [##\<LINESTYLE>\<LINECOLOR>] [\<EXTENDS>[,\<EXTENDS>]] [\<IMPLEMENTS>[,\<IMPLEMENTS>]]                            | no          |                         |
| hide [\<NAME>] [empty] \<PORTION>                                                                                                                                                                       | yes         | `HideEntityPortion`     |
| show [\<NAME>] [empty] \<PORTION>                                                                                                                                                                       | no          |                         |
| hide \<VISIBILITY>[,\<VISIBILITY>*] \<PORTION>                                                                                                                                                          | yes         | `HideEntityPortion`     |
| show \<VISIBILITY>[,\<VISIBILITY>*] \<PORTION>                                                                                                                                                          | no          |                         |
| set namespaceseparator \<SEPARATOR>                                                                                                                                                                     | yes         | `SetNamespaceSeparator` |

## Sequence Diagrams

| Command                                                              | Implemented | Method              |
| -------------------------------------------------------------------- | ----------- | ------------------- |
| activate \<WHO> [\<BGCOLOR>] [\<LNCOLOR>]                            | yes         | `Activate`          |
| deactivate \<WHO> [\<BGCOLOR>] [\<LNCOLOR>]                          | partial     | `Deactivate`        |
| deactivate                                                           | yes         | `Deactivate`        |
| destroy \<WHO> [\<BGCOLOR>] [\<LNCOLOR>]                             | partial     | `Destroy`           |
| \<NAME>++ [\<BGCOLOR>]                                               | no          |                     |
| \<NAME>-- [\<BGCOLOR>]                                               | no          |                     |
| autonewpage                                                          | no          |                     |
| autoactivate off\|on                                                 | yes         | `AutoActivate`      |
| autonumber [\<START>] [\<STEP>] [\<FORMAT>]                          | yes         | `AutoNumber`        |
| autonumber inc                                                       | no          |                     |
| autonumber resume [\<STEP>] [\<FORMAT>]                              | yes         | `ResumeAutoNumber`  |
| autonumber stop                                                      | yes         | `StopAutoNumber`    |
| box [\<NAME>] [\<STEREO>] [\<COLOR>]                                 | partial     | `BoxStart`          |
| end box                                                              | yes         | `BoxEnd`            |
| delay [\<LABEL>]                                                     | yes         | `Delay`             |
| divider [\<LABEL>]                                                   | yes         | `Divider`           |
| hide footbox                                                         | no          |                     |
| show footbox                                                         | no          |                     |
| opt [\<COLOR>] [\<COMMENT>]                                          | no          |                     |
| end                                                                  | yes         | `GroupEnd`          |
| alt [\<COLOR>] [\<COMMENT>]                                          | partial     | `AltStart`          |
| end                                                                  | yes         | `GroupEnd`          |
| loop [\<COLOR>] [\<COMMENT>]                                         | partial     | `StartLoop`         |
| end                                                                  | yes         | `EndLoop`           |
| par [\<COLOR>] [\<COMMENT>]                                          | no          |                     |
| end                                                                  | yes         | `GroupEnd`          |
| par2 [\<COLOR>] [\<COMMENT>]                                         | no          |                     |
| end                                                                  | yes         | `GroupEnd`          |
| break [\<COLOR>] [\<COMMENT>]                                        | no          |                     |
| end                                                                  | yes         | `GroupEnd`          |
| critical [\<COLOR>] [\<COMMENT>]                                     | no          |                     |
| end                                                                  | yes         | `GroupEnd`          |
| else [\<COLOR>] [\<COMMENT>]                                         | partial     | `ElseStart`         |
| end                                                                  | yes         | `GroupEnd`          |
| also [\<COLOR>] [\<COMMENT>]                                         | no          |                     |
| end                                                                  | yes         | `GroupEnd`          |
| group [\<COLOR>] [\<COMMENT>]                                        | partial     | `GroupStart`        |
| end                                                                  | yes         | `GroupEnd`          |
| ignore newpage                                                       | no          |                     |
| newpage [\<TITLE>]                                                   | yes         | `NewPage`           |
| create [order \<ORDER>] [\<URL>] [\<COLOR>]                          | partial     | `Create`            |
| participant \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]             | partial     | `Participant`       |
| actor \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]                   | partial     | `Actor`             |
| create actor \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]            | partial     | `CreateActor`       |
| boundary \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]                | partial     | `Boundary`          |
| create boundary \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]         | partial     | `CreateBoundary`    |
| collections \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]             | partial     | `Collections`       |
| create collections \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]      | partial     | `CreateCollections` |
| control \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]                 | partial     | `Control`           |
| create control \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]          | partial     | `CreateControl`     |
| entity \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]                  | partial     | `Entity`            |
| create entity \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]           | partial     | `CreateEntity`      |
| database \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]                | partial     | `Database`          |
| create database \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]         | partial     | `CreateDatabase`    |
| queue \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]                   | partial     | `Queue`             |
| create queue \<NAME> [order \<ORDER>] [\<URL>] [\<COLOR>]            | partial     | `CreateQueue`       |
| ref[\<COLOR>] over \<NAME>[,\<NAME>] : [\<URL>] [\<TEXT>]            | partial     | `Ref`               |
| ref[\<COLOR>] over \<NAME>[,\<NAME>]                                 | partial     | `StartRef`          |
| end ref                                                              | yes         | `EndRef`            |
| return [\<COLOR>] \<MESSAGE>                                         | partial     | `Return`            |
| space                                                                | yes         | `Space`             |
| [r\|h]note \<POSITION> [\<BGCOLOR>] : \<NOTE>                        | yes         | `Note`              |
| [r\|h]note over \<PARTICIPANT>,\<PARTICIPANT> [\<BGCOLOR>] : \<NOTE> | yes         | `Note`              |
| [r\|h]note \<POSITION> of \<PARTICIPANT> [\<BGCOLOR>] : \<NOTE>      | yes         | `Note`              |
| [r\|h]note \<POSITION> [\<BGCOLOR>]                                  | yes         | `StartNote`         |
| [r\|h]note over \<PARTICIPANT>,\<PARTICIPANT> [\<BGCOLOR>]           | yes         | `StartNote`         |
| [r\|h]note \<POSITION> of \<PARTICIPANT> [\<BGCOLOR>]                | yes         | `StartNote`         |
| end note                                                             | yes         | `EndNote`           |
| end hnote                                                            | yes         | `EndHNote`          |
| end rnote                                                            | yes         | `EndRNote`          |
