# *PriAware*: Exploring Enhancing Privacy Awareness in AR Users
This repository contains the three-level privacy guidance prototypes described in my master's thesis advised by Professor Michael Nebeling and Shwetha Rajaram.

**_PriAware_** is a concept of three-level privacy guidance to help enhance AR users privacy awareness in everyday always-on AR usage through both visual and audio cues. 

Read the full paper here >> [PriAware: Exploring Enhancing Privacy Awareness in AR Users](https://backend.production.deepblue-documents.lib.umich.edu/server/api/core/bitstreams/0bf1352c-c958-48d9-813a-cf39380208b8/content)

## Backgroun and Motivation
Advancement and rising adoption in AR technology will soon enable every-day always-on usage of AR, but can introduce novel privacy concerns for both end-users and bystanders, due to its invasive sensing capabilities.

For example, spatial mapping can reveal a user’s exact location and physical configuration. Voice recognition and object detection can enable further profiling and inference of sensitive information. Those novel privacy risks are oftentimes difficult for users to recognize, especially those without technical knowledge of how AR system work. 

Most existing work focuses on system-level privacy protections, which users tend to disengage from if they don’t understand the underlying risks. This raises a critical need to educate AR users to raise their privacy awareness.

Our work addresses this by introducing a three-level privacy guidance approach that uses progressive feedback to support user’s privacy awareness.

- Level 1: What is Captured? (Highlight what's within the sensing range.)
- Level 2: What is Detected? (Highlight what's recognized by the system (objects, environments, people.)
- Level 3: What is Inferred? (Explain potential privacy risks.)

## Privacy Guidance Design

| ![Privacy Guidance Levels Organized by Level of Guidance](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/Privacy%20Guidance%20Levels.png) | 
|:--:| 
| *Privacy Guidance Levels Organized by Level of Guidance* |

| ![Privacy Guidance Cues Organized by Privacy Guidance Levels.](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/Privacy%20Guidance%20Cues%20Organized%20by%20Privacy%20Guidance%20Levels.png) | 
|:--:| 
| *Privacy Guidance Cues Organized by Privacy Guidance Levels.* |

## Privacy Guidance Prototpye
We created 3 AR usage scenarios for the evaluation of the privacy guidance, differing in the space (namely private, semipublic, and public).
![AR usage scenarios](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/privacy-guidance-scenarios.png)

| Level 1 - What is Captured?  | Level 2 - What is Detected? | Level 3 - What is Inferred?|
|:--:|:--:|:--:|
|Personal Home Office|Shared Classroom| Public Park |
|![Level 1 with Annotations](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/level-1-annotations.png)|![Level 2 with Annotations](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/level-2-annotations.png)|![Level 3 with Annotations](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/level-3-annotations.png)|
|![Level 1 prototype](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/guidance-level-1.gif)|![Level 2 prototype](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/guidance-level-2.gif)|![Level 3 prototype](https://github.com/AnhuaW/AnhuaW.github.io/blob/main/guidance-level-3.gif)|
