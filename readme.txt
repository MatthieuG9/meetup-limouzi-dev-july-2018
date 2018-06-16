1- Mise en place du décor

Parler des gamesobjects
Des sprites
Des sorting layers
Important de bien organiser (gameobjects parent + position à zero)
Création d'une skybox (présentation rapide des materials).


2- Mise en place des colliders et de la gravité

Explication sur les box2d
Mise en place d'un top et d'un bottom (qui doit dépasser du collider)
Attention au layer
Création du material physics
Création du script grounded

3- Ajout des controles

Présentation des inputs
Astuce pour gérer deux players sur le même clavier
Utiliser bouton down
Réglage de la physique
Différence update, fixed update

4- Ajout des platformers pour résoudre les problèmes de collision

5- Mise en place des animations
Création d'une machine à états
Signaler uniquement les changements d'états
Attention, bien configurer les transitions 
(peuvent être interrompues + durée = 0)
Bien connecter tous les états

6- Détection des dégats
Ajout d'un objet enfant
Ajout d'un collider
Configuration de la physique
Mise en place du script pour appeler la méthode hit
Ajout d'une méthode hide

7- Ajout des sons
Utilisation de broadcast message
