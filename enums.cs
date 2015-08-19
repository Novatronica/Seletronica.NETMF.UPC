using System;
using Microsoft.SPOT.Hardware;

namespace Seletronica.NETMF.UPC.Enums
{
    public enum CpuRes
    {
        LED_RUN = Pin.PD1,
        LED_COM = Pin.PD0,
        COM_TX = Pin.PB10,
        COM_RX = Pin.PB11,
    }

    public enum Relays
    {
        RELAY_1 = Pin.PD4,
        RELAY_2 = Pin.PC7,
        RELAY_3 = Pin.PG9,
        RELAY_4 = Pin.PG11,
        RELAY_5 = Pin.PG13,
        RELAY_6 = Pin.PG15,
        RELAY_7 = Pin.PC6,
        RELAY_8 = Pin.PD7,
        RELAY_9 = Pin.PG10,
        RELAY_10 = Pin.PG12,
        RELAY_11 = Pin.PG14,
        RELAY_12 = Pin.PB5,
    }

    public enum DualRelaysModule
    {
        RELAY_A1 = Pin.PD5,
        RELAY_B1 = Pin.PD6,
        RELAY_A2 = Pin.PA0,
        RELAY_B2 = Pin.PA1,
        RELAY_A3 = Pin.PA2,
        RELAY_B3 = Pin.PA3,
        RELAY_A4 = Pin.PC0,
        RELAY_B4 = Pin.PC1,
        RELAY_A5 = Pin.PA6,
        RELAY_B5 = Pin.PA7,
        RELAY_A6 = Pin.PB0,
        RELAY_B6 = Pin.PB1,
        RELAY_A7 = Pin.PA4,
        RELAY_B7 = Pin.PA5,
        RELAY_A8 = Pin.PC2,
        RELAY_B8 = Pin.PC3,
        RELAY_A9 = Pin.PC4,
        RELAY_B9 = Pin.PC5,
        RELAY_A10 = Pin.PF3,
        RELAY_B10 = Pin.PF4,
        RELAY_A11 = Pin.PF5,
        RELAY_B11 = Pin.PF6,
        RELAY_A12 = Pin.PF7,
        RELAY_B12 = Pin.PF8,
    }

    public enum Output
    {
        OUT_A1 = Pin.PD5,
        OUT_B1 = Pin.PD6,
        OUT_C1 = Pin.PD4,
        OUT_A2 = Pin.PA0,
        OUT_B2 = Pin.PA1,
        OUT_C2 = Pin.PC7,
        OUT_A3 = Pin.PA2,
        OUT_B3 = Pin.PA3,
        OUT_C3 = Pin.PG9,
        OUT_A4 = Pin.PC0,
        OUT_B4 = Pin.PC1,
        OUT_C4 = Pin.PG11,
        OUT_A5 = Pin.PA6,
        OUT_B5 = Pin.PA7,
        OUT_C5 = Pin.PG13,
        OUT_A6 = Pin.PB0,
        OUT_B6 = Pin.PB1,
        OUT_C6 = Pin.PB1,
        OUT_A7 = Pin.PA4,
        OUT_B7 = Pin.PA5,
        OUT_C7 = Pin.PC6,
        OUT_A8 = Pin.PC2,
        OUT_B8 = Pin.PC3,
        OUT_C8 = Pin.PD7,
        OUT_A9 = Pin.PC4,
        OUT_B9 = Pin.PC5,
        OUT_C9 = Pin.PG10,
        OUT_A10 = Pin.PF3,
        OUT_B10 = Pin.PF4,
        OUT_C10 = Pin.PG12,
        OUT_A11 = Pin.PF5,
        OUT_B11 = Pin.PF6,
        OUT_C11 = Pin.PG14,
        OUT_A12 = Pin.PF7,
        OUT_B12 = Pin.PF8,
        OUT_C12 = Pin.PB5,
    }

    public enum Opto
    {
        OPTO_A1 = Pin.PD5,
        OPTO_B1 = Pin.PD6,
        OPTO_A2 = Pin.PA0,
        OPTO_B2 = Pin.PA1,
        OPTO_A3 = Pin.PA2,
        OPTO_B3 = Pin.PA3,
        OPTO_A4 = Pin.PC0,
        OPTO_B4 = Pin.PC1,
        OPTO_A5 = Pin.PA6,
        OPTO_B5 = Pin.PA7,
        OPTO_A6 = Pin.PB0,
        OPTO_B6 = Pin.PB1,
        OPTO_A7 = Pin.PA4,
        OPTO_B7 = Pin.PA5,
        OPTO_A8 = Pin.PC2,
        OPTO_B8 = Pin.PC3,
        OPTO_A9 = Pin.PC4,
        OPTO_B9 = Pin.PC5,
        OPTO_A10 = Pin.PF3,
        OPTO_B10 = Pin.PF4,
        OPTO_A11 = Pin.PF5,
        OPTO_B11 = Pin.PF6,
        OPTO_A12 = Pin.PF7,
        OPTO_B12 = Pin.PF8,
    }

    public enum Input
    {
        IN_A1 = Pin.PD5,
        IN_B1 = Pin.PD6,
        IN_A2 = Pin.PA0,
        IN_B2 = Pin.PA1,
        IN_A3 = Pin.PA2,
        IN_B3 = Pin.PA3,
        IN_A4 = Pin.PC0,
        IN_B4 = Pin.PC1,
        IN_A5 = Pin.PA6,
        IN_B5 = Pin.PA7,
        IN_A6 = Pin.PB0,
        IN_B6 = Pin.PB1,
        IN_A7 = Pin.PA4,
        IN_B7 = Pin.PA5,
        IN_A8 = Pin.PC2,
        IN_B8 = Pin.PC3,
        IN_A9 = Pin.PC4,
        IN_B9 = Pin.PC5,
        IN_A10 = Pin.PF3,
        IN_B10 = Pin.PF4,
        IN_A11 = Pin.PF5,
        IN_B11 = Pin.PF6,
        IN_A12 = Pin.PF7,
        IN_B12 = Pin.PF8,
    }

    public enum ADC
    {
        ADC_A3 = 1,
        ADC_B3 = 2,
        ADC_A4 = 3,
        ADC_B4 = 4,
        ADC_A5 = 0,
        ADC_A6 = 9,
        ADC_B6 = 10,
        ADC_A7 = 5,
        ADC_B7 = 8,
        ADC_A8 = 6,
        ADC_B8 = 7,
    }

    public enum DAC
    {
        DAC_A7 = 0,
        DAC_B7 = 1,
    }

    public enum OW_Pin
    {
        One_Wire_A1 = Pin.PD5,
        One_Wire_B1 = Pin.PD6,
        One_Wire_A2 = Pin.PA0,
        One_Wire_B2 = Pin.PA1,
        One_Wire_A3 = Pin.PA2,
        One_Wire_B3 = Pin.PA3,
        One_Wire_A4 = Pin.PC0,
        One_Wire_B4 = Pin.PC1,
        One_Wire_A5 = Pin.PA6,
        One_Wire_B5 = Pin.PA7,
        One_Wire_A6 = Pin.PB0,
        One_Wire_B6 = Pin.PB1,
        One_Wire_A7 = Pin.PA4,
        One_Wire_B7 = Pin.PA5,
        One_Wire_A8 = Pin.PC2,
        One_Wire_B8 = Pin.PC3,
        One_Wire_A9 = Pin.PC4,
        One_Wire_B9 = Pin.PC5,
        One_Wire_A10 = Pin.PF3,
        One_Wire_B10 = Pin.PF4,
        One_Wire_A11 = Pin.PF5,
        One_Wire_B11 = Pin.PF6,
        One_Wire_A12 = Pin.PF7,
        One_Wire_B12 = Pin.PF8,
    }

    public enum RS232
    {  
        RS232_1 = 3,
        RS232_2 = 2,
    }

    public enum RS485
    {
        RS485_1 = 3,
        RS485_2 = 2,
    }

    public enum TxEnable
    {
        TX_ENABLE_1 = Pin.PD4,
        TX_ENABLE_2 = Pin.PG9,
    }

    public enum UIODigitalInput
    {
        UIO_IN_1 = Pin.PD6,
        UIO_IN_2 = Pin.PA1,
        UIO_IN_3 = Pin.PA3,
        UIO_IN_4 = Pin.PC1,
        UIO_IN_5 = Pin.PA7,
        UIO_IN_6 = Pin.PB1,
        UIO_IN_7 = Pin.PA5,
        UIO_IN_8 = Pin.PC3,
        UIO_IN_9 = Pin.PC5,
        UIO_IN_10 = Pin.PF4,
        UIO_IN_11 = Pin.PF6,
        UIO_IN_12 = Pin.PF8,
    }

    public enum UIODigitalOutput
    {
        UIO_OUT_1 = Pin.PD5,
        UIO_OUT_2 = Pin.PA0,
        UIO_OUT_3 = Pin.PA2,
        UIO_OUT_4 = Pin.PC0,
        UIO_OUT_5 = Pin.PA6,
        UIO_OUT_6 = Pin.PB0,
        UIO_OUT_7 = Pin.PA4,
        UIO_OUT_8 = Pin.PC2,
        UIO_OUT_9 = Pin.PC4,
        UIO_OUT_10 = Pin.PF3,
        UIO_OUT_11 = Pin.PF5,
        UIO_OUT_12 = Pin.PF7,
    }

    public enum UIO_ADC
    {
        UIO_ADC_3 = 2,
        UIO_ADC_4 = 4,
        UIO_ADC_6 = 10,
        UIO_ADC_7 = 8,
        UIO_ADC_8 = 7,
    }

    public enum UIOSoftPWM
    {
        SPWM_2 = Pin.PA0,
        SPWM_3 = Pin.PA2,
        SPWM_4 = Pin.PC0,
        SPWM_5 = Pin.PA6,
        SPWM_7 = Pin.PA4,
        SPWM_8 = Pin.PC2,
        SPWM_9 = Pin.PC4,
        SPWM_10 = Pin.PF3,
        SPWM_11 = Pin.PF5,
        SPWM_12 = Pin.PF7,
    }

    public enum UIORealPWM
    {
        RPWM_1 = 10,
        RPWM_6 = 4,
    }

    public enum UIOSoftDAC
    {
        DAC_SPWM_2 = Pin.PA0,
        DAC_SPWM_3 = Pin.PA2,
        DAC_SPWM_4 = Pin.PC0,
        DAC_SPWM_5 = Pin.PA6,
        DAC_SPWM_7 = Pin.PA4,
        DAC_SPWM_8 = Pin.PC2,
        DAC_SPWM_9 = Pin.PC4,
        DAC_SPWM_10 = Pin.PF3,
        DAC_SPWM_11 = Pin.PF5,
        DAC_SPWM_12 = Pin.PF7,
    }

    public enum UIORealDAC
    {
        DAC_RPWM_1 = 10,
        DAC_RPWM_6 = 4,
    }

    public enum UIOSelector
    {
        OUT_SEL_1 = Pin.PD4,
        OUT_SEL_2 = Pin.PC7,
        OUT_SEL_3 = Pin.PG9,
        OUT_SEL_4 = Pin.PG11,
        OUT_SEL_5 = Pin.PG13,
        OUT_SEL_6 = Pin.PG15,
        OUT_SEL_7 = Pin.PC6,
        OUT_SEL_8 = Pin.PD7,
        OUT_SEL_9 = Pin.PG10,
        OUT_SEL_10 = Pin.PG12,
        OUT_SEL_11 = Pin.PG14,
        OUT_SEL_12 = Pin.PB5,
    }

    public enum UIOMode
    {
        UIOModeDigitalInput = 1,
        UIOModeDigitalOutput = 2,
        UIOModeAnalogInput = 3,
        UIOModeSoftPwm = 4,
        UIOModeRealPwm = 5,
        UIOModeSoftDac = 6,
        UIOModeRealDac = 7,
    }

}
