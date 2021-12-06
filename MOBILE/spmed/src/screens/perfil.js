import React from "react";

import{
    View,
    Text,
    StyleSheet
} from 'react-native'

export default function Perfil() {
    return(
        <View style={styles.main}>
            <Text style={styles.mainText}>{"Tela em construção...".toUpperCase()}</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    main:{
        justifyContent: 'center',
        alignItems: 'center',
        width: "100%",
        height: '100%'
    },
    mainText:{
        fontFamily:'TitilliumWeb-Regular',
        fontSize: 28,
        color: '#000'
    }
})