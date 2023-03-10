p1eXu5.Wpf.DigitPanel
=====================

| Package                     | Versions                                                                                                                     |
| --------------------------- | ---------------------------------------------------------------------------------------------------------------------------- |
| p1eXu5.Wpf.DigitPanel       | [![NuGet](https://img.shields.io/badge/nuget-1.0.1-brightgreen)](https://www.nuget.org/packages/p1eXu5.Wpf.DigitPanel/1.0.1) |

![digit-panel](./images/digit-panel.png)

## Usage:

```xml
<Application x:Class="YourApp"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:digitPanel="clr-namespace:p1eXu5.Wpf.DigitPanel;assembly=p1eXu5.Wpf.DigitPanel"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <digitPanel:DigitPanelTheme />
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

```xml
<Window ...
             xmlns:digitPanel="clr-namespace:p1eXu5.Wpf.DigitPanel;assembly=p1eXu5.Wpf.DigitPanel"
             ...
             Background="{DynamicResource {x:Static digitPanel:DigitPanelColors.DigitPanelBackgroundKey}}"
             >
             
  <digitPanel:Digit DockPanel.Dock="Left" Foreground="#FF0000" Background="#BBBBBB" IsDotOn="True" DotVisibility="Collapsed" Width="160" Mask="0"/>

  <digitPanel:DigitTable Grid.Column="0" 
                         DigitWidth="140"
                         Value="0"
                         Height="500" 
                         Width="800"
                         Format="##0.00"
                         />

  <digitPanel:TimerTable Grid.Column="0" 
                         DigitWidth="45"
                         Value="12:12:12"
                         Height="100" 
                         Width="300"/>
```

<br/>

## Digit Properties

| Property | Type | Description |
|----------|------|-------------|
| **Mask** | `string` | Determines which digit segments are lit. `"0"` - all digits are off, `"1"` - all digits are on. `"0100101"` - top-left, top-middle, top-right, middle, bottom-left, bottom-middle, bottom-right. |
| **ActiveRadius** | `double` | Booster-light. Active digit segment shaddow radius. |
| **InactiveRadius** | `double` | Booster-light. Inactive digit segment shaddow radius. |
| **IsDotOn** | `bool` | If true then dot is lit. |
| **DotVisibility** | `Visibility` | Dot visibility property. |
| **IsColonOn** | `bool` | If true then colon is lit. |
| **ColonVisibility** | `Visibility` | Colon visibility property. |


<br/>

## DigitTableBase Properties

| Property | Type | Description |
|----------|------|-------------|
| **Foreground** | `Brush` | Active digit segments color. |
| **DigitBackground** | `Brush` | Inactive digit segments color. |
| **Background** | `Brush` | Digit table background. |
| **DigitWidth** | `double` | Size of digit. |

<br/>

## DigitTable Properties (inherit DigitTableBase properties)

| Property | Type | Description |
|----------|------|-------------|
| **Value** | `double?` | Value showing on digit table. |
| **Format** | `string` | Value format. For example: `"##0.00"` |

<br/>

## TimerTable Properties (inherit DigitTableBase properties)

| Property | Type | Description |
|----------|------|-------------|
| **Value** | `TimeSpan` | Value showing on digit table. |
