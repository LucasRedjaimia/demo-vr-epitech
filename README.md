# Game Design Document

## 1. Vue d'Ensemble du Projet

- **Genre** : Horreur psychologique, Survie, Exploration (en Réalité Virtuelle)
- **Plateformes Cibles** : Casques VR (PC VR, Standalone VR)
- **Public Cible** : Joueurs de 16 ans et plus, amateurs de jeux d'horreur psychologique et d’expériences immersives en VR
- **Concept Clé** :  
  Plonger le joueur dans une forêt nocturne et oppressante où l’absence de menace visible est remplacée par une ambiance terrifiante et la gestion de ressources limitées.  
  L’horreur est suggérée par l’environnement, le son et l’isolement. Inspiré du gameplay atmosphérique de *Slender Man* et de la gestion d’inventaire pratique de *Phasmophobia*.

---

## 2. Gameplay

### 2.1 Objectif Principal du Joueur

Explorer une vaste forêt plongée dans l’obscurité et le brouillard pour trouver un certain nombre de **pages** dispersées.  
La collecte de toutes les pages mène à la **conclusion du jeu** (évasion ou autre objectif final).

### 2.2 Mécaniques de Jeu

- **Exploration**  
  Navigation libre dans un environnement forestier dense et non linéaire. Des points d’intérêt (cabanes, ruines…) guident ou désorientent la recherche des pages.

- **Mouvement**  
  Locomotion fluide (téléportation ou déplacement continu), avec options pour limiter le mal des transports.

- **Gestion de l'Inventaire** *(inspiration Phasmophobia)*  
  - Emplacements physiques sur le corps (poche, ceinture)
  - Objets :
    - **Lampe torche** : source principale de lumière, se décharge avec le temps.
    - **Piles** : nécessaires pour recharger la lampe.
    - **Bandages** : pour soigner le joueur (système de santé avec saignement).
  - Interactions physiques en VR (saisir, insérer des piles, appliquer un bandage).

- **Absence de Combat**  
  Aucune arme ni combat. La survie repose sur la fuite, la dissimulation, et la gestion des ressources.

---

## 3. Environnement et Ambiance

### 3.1 Cadre

- **Lieu** : Forêt dense et labyrinthique
- **Heure** : Nuit noire avec lune visible
- **Météo** : Brouillard épais et omniprésent

### 3.2 Direction Artistique

- **Style visuel** : Réaliste avec touche stylisée pour accentuer l’horreur.  
  Palette : tons sombres, verts profonds, gris + lumière de la torche.
- **Éclairage** : Principalement la lampe du joueur, quelques lumières statiques dans des points d’intérêt.
- **Points d’intérêt** : Cabanes en ruine, hangars, ruines anciennes...

### 3.3 Design Sonore (crucial)

- **Bruitages d’ambiance** : Vent, branches, feuilles, chouettes, insectes, pas...
- **Sons atmosphériques** : Drones, murmures, bruits ambigus pour suggérer une présence invisible.
- **Audio spatialisée** : Sons directionnels pour immersion et désorientation.

### 3.4 Thèmes de l’Horreur

- Peur de l’inconnu
- Isolement
- Impossibilité de se défendre
- Gestion du stress par les ressources limitées

---

## 4. Interfaces Utilisateur (UI)

- **Diegetic UI** : Interface intégrée dans le monde. Ex : niveau de batterie visible sur la lampe.
- **Inventaire** : Physique (objets visibles et interactifs sur le corps).
- **Indicateurs santé** : Subtils et immersifs (vision floue, battements de cœur, teinte rouge).

---

## 5. Progression

- **Objectif principal** : Collecter X pages
- **Exploration** : Non-linéaire, chaque joueur peut trouver les pages dans l’ordre qu’il souhaite.
