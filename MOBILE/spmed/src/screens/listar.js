import React, { useState, useEffect } from "react";

import {
    StyleSheet,
    Text,
    View,
    Image,
    FlatList,
} from 'react-native';

import {TouchableOpacity} from 'react-native-gesture-handler';

import api from '../services/api'

import AsyncStorage from '@react-native-async-storage/async-storage';
import { set } from "react-native-reanimated";

export default function Consultas() {
    const [listaConsultas, setListaConsultas] = useState([]);
    

    async function BuscarConsultas (){
        const token = await AsyncStorage.getItem('userToken');

        const resposta = await api.get('/consultas/listar/minhas', {
            headers: {
                'Authorization': 'Bearer ' + token
            }
        })

        const dadosDaApi = resposta.data.listaConsultas;

        setListaConsultas(dadosDaApi)
    }

    useEffect(BuscarConsultas, [])

    return(
        <View>
            <Text>Ahhh</Text>
        </View>
    )
}

const styles = StyleSheet.create({

})