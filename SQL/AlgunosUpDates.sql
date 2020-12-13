-- SQLite
update Medico set especialidad = 'Cardiología Intervencionista'
where id=18;
update Medico set especialidad = 'Cardiología Intervencionista'
where id=21;

update Medico set especialidad = 'Cardiología Pediátrica'
where id=32;
update Medico set especialidad = 'Cardiología Pediátrica'
where id=33;

update Medico set especialidad = 'Gastroenterología'
where id=36;
update Medico set especialidad = 'Ginecología'
where id=52;


update Medico set rolEnEspecialidad = 'Médica de Planta'
where id=18;
update Medico set rolEnEspecialidad = 'Médica de Planta'
where id=21;

update Medico set rolEnEspecialidad = 'Médica de Planta'
where id=32;
update Medico set rolEnEspecialidad = 'Médica de Planta'
where id=33;

update Nota set URLImagen = '/Imagenes/notaCovid19.jpg'
where id=159;
update Nota set URLImagen = '/Imagenes/notaChequeate.jpg'
where id=160;
update Nota set URLImagen = '/Imagenes/notaConsecuencias.jpg'
where id=161;

update Nota set URLNotaCompleta = 'https://www.fundacionfavaloro.org/restriccion_de_visitas/'
where id=159;
update Nota set URLNotaCompleta = 'https://www.fundacionfavaloro.org/programa-chequeate-en-casa/'
where id=160;
update Nota set URLNotaCompleta = 'https://www.fundacionfavaloro.org/consecuencias-de-la-cuarentena-eterna/'
where id=161;

