import React, { useState, useEffect } from "react";

import {
    StyleSheet,
    Text,
    View,
    Image,
    FlatList,
} from 'react-native';

import {TouchableOpacity} from 'react-native-gesture-handler';

import AsyncStorage from '@react-native-async-storage/async-storage';

export default function Consultas() {
    const [listaConsultas, setListaConsultas] = useState([]);
    const token = await AsyncStorage.getItem('userToken');

    
}
